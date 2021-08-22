import { classnameModel } from './../../../models/class-name/classname.model';
import { ToastrService } from 'ngx-toastr';
import { ClassNameService } from './../../../services/classname/classname.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { Component, OnInit, ViewChild } from '@angular/core';

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
  user:classnameModel;

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private classnameService:ClassNameService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getAll();
    this.saveClassNameForm = this.fb.group({
      Name:['', Validators.required],
      Description:['', Validators.required],
    });
  }

  getAll(){

  }

  saveClassName(content){
    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    })
  }

  editRow(row, rowIndex, content) {
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

  deleteSingleRow(row) {

  }

  addRecordSuccess() {
    this.toastr.success('ClassName Add Successfully', '');
  }
}
