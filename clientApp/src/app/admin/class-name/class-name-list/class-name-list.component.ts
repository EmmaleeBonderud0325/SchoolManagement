import { classnameModel } from './../../../models/class-name/classname.model';
import { ToastrService } from 'ngx-toastr';
import { ClassNameService } from './../../../services/classname/classname.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { Component, OnInit, ViewChild } from '@angular/core';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-class-name-list',
  templateUrl: './class-name-list.component.html',
  styleUrls: ['./class-name-list.component.sass'],
  providers: [ToastrService],
})
export class ClassNameListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  saveClassNameForm:FormGroup;
  reorderable = true;
  classname:classnameModel;

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private classnameService:ClassNameService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.saveClassNameForm = this.fb.group({
      Name:['', Validators.required],
      Description:['', Validators.required],
      isActive: ['', [Validators.required]],
    });
    this.getAll();
  }

  getAll(){
    this.loadingIndicator=true;
    this.classnameService.getAll().subscribe(response=>
    {
      this.data= response;
      this.loadingIndicator=false;
    },error=>{
      this.loadingIndicator=false;
    });
  }

  addNewClassName(content){
    this.saveClassNameForm = this.fb.group({
      name: ['', [Validators.required, Validators.pattern('[a-zA-Z]+')]],
      Description:['', Validators.required],
      isActive: ['', [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

  onAddRowSave(form: FormGroup) {
    this.data.push(form.value);
    this.data = [...this.data];
    form.reset();
    this.modalService.dismissAll();
    this.addRecordSuccess();
  }

  editRow(row:classnameModel, rowIndex:number, content:any) {
    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });

    this.saveClassNameForm = this.fb.group({
      name: [row.name, [Validators.required, Validators.pattern('[a-zA-Z]+')]],
      description: [row.description,[Validators.required, Validators.pattern('[0-9]+[a-zA-Z]+')]],
      isActive: [row.isActive, [Validators.required]],
    });
  }

  deleteSingleRow(row) {

  }

  addRecordSuccess() {
    this.toastr.success('ClassName Add Successfully', '');
  }
}
