import { AcademicYearModel } from './../../../models/academic-Year/academic.Year.model';
import { DropDownModel } from './../../../models/common/drop-down.model';
import { AcademicYearService } from './../../../services/academic-Year/academic-Year.service';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-academic-year-list',
  templateUrl: './academic-year-list.component.html',
  styleUrls: ['./academic-year-list.component.sass'],
  providers: [ToastrService],
})
export class AcademicYearListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  academicYearFrom:FormGroup;
  reorderable = true;
  academicYear:AcademicYearModel;
  
  
  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private academicYearService:AcademicYearService,
    private toastr: ToastrService) { }

  ngOnInit(): void {

    this.academicYearFrom = this.fb.group({
      name: ['', [Validators.required, Validators.pattern('[0-9]+')]],
      isActive: ['', [Validators.required]],
    });
    this.getAll();
    
  }
  
  getAll()
  {
    this.loadingIndicator=true;
    this.academicYearService.getAll().subscribe(response=>
    {
        this.data= response;
        this.loadingIndicator=false;
    },error=>{
      this.loadingIndicator=false;
    });
  }


  addNewAcademicYear(content) {

    this.academicYearFrom = this.fb.group({
      name: ['', [Validators.required, Validators.pattern('[0-9]+')]],
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


  editRow(row:AcademicYearModel, rowIndex:number, content:any) {
    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });

    this.academicYearFrom = this.fb.group({
      name: [row.name, [Validators.required, Validators.pattern('[0-9]+')]],
      isActive: [row.isActive, [Validators.required]],
    });
  }

    deleteSingleRow(row) {

    }

    addRecordSuccess() {
      this.toastr.success('Acedemic Year Added Successfully', '');
    }
}
