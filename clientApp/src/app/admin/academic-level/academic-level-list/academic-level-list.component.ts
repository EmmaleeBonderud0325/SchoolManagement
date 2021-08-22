import { AcademicLevelModel } from './../../../models/academic-level/acdemic.level.model';
import { DropDownModel } from './../../../models/common/drop-down.model';
import { AcademicLevelService } from './../../../services/academic-level/academic-level.service';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-academic-level-list',
  templateUrl: './academic-level-list.component.html',
  styleUrls: ['./academic-level-list.component.sass'],
  providers: [ToastrService],
})
export class AcademicLevelListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  academicLevelFrom:FormGroup;
  reorderable = true;
  academicLevel:AcademicLevelModel;
  levelHeads:DropDownModel[] = [];

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private academicLevelService:AcademicLevelService,
    private toastr: ToastrService) { }

  ngOnInit(): void {

    this.academicLevelFrom = this.fb.group({
      name: ['', [Validators.required, Validators.pattern('[a-zA-Z]+')]],
      selectlevelHeadId: [null, [Validators.required]],
      isActive: ['', [Validators.required]],
    });
    this.getAll();
    this.getAllLevelHeads();

  }
  
  getAllLevelHeads(){
      this.academicLevelService.getAllLevelHeads()
        .subscribe(response=>{

          console.log(response);
          
          this.levelHeads = response;
        },error=>{

        });
  }
  getAll()
  {
    this.loadingIndicator=true;
    this.academicLevelService.getAll().subscribe(response=>
    {
        this.data= response;
        this.loadingIndicator=false;
    },error=>{
      this.loadingIndicator=false;
    });
  }


  addNewAcademicLevel(content) {

    this.academicLevelFrom = this.fb.group({
      name: ['', [Validators.required, Validators.pattern('[a-zA-Z]+')]],
      selectlevelHeadId: [null, [Validators.required]],
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


  editRow(row:AcademicLevelModel, rowIndex:number, content:any) {
    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });

    this.academicLevelFrom = this.fb.group({
      name: [row.name, [Validators.required, Validators.pattern('[a-zA-Z]+')]],
      selectlevelHeadId: [row.selectedLevelHeadId, [Validators.required]],
      isActive: [row.isActive, [Validators.required]],
    });
  }

    deleteSingleRow(row) {

    }

    addRecordSuccess() {
      this.toastr.success('Acedemic Level Add Successfully', '');
    }
}
