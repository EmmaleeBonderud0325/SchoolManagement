import { MessageService } from 'primeng/api';
import { DropDownModel } from './../../../models/common/drop-down.model';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';
import { HeadOfDepartmentService } from './../../../services/head-of-department/head-of-department.service';
import { HeadOfDepartmentModel } from 'src/app/models/head-of-department/head.of.department.model';
import { NgxSpinnerService } from 'ngx-spinner';
import { BasicHeadOfDepartmentModel } from 'src/app/models/head-of-department/basic.head.of.department.model';

@Component({
  selector: 'app-head-of-department-list',
  templateUrl: './head-of-department-list.component.html',
  styleUrls: ['./head-of-department-list.component.scss'],
  providers: [MessageService],
})
export class HeadOfDepartmentListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  
  headOfDepartmentFilterForm:FormGroup;
  headOfDepartmentFrom:FormGroup;

  currentPage: number = 0;
  pageSize: number = 10;
  totalRecord: number = 0;

  subjects:DropDownModel[] = [];
  academicYears:DropDownModel[] = [];
  academicLevels:DropDownModel[] = [];
  teachers:DropDownModel[]=[];
  reorderable = true;

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private headOfDepartmentService:HeadOfDepartmentService,
    private spinner:NgxSpinnerService,
    private messageService: MessageService) { }

  ngOnInit(): void {
    //this.spinner.show();
    this.headOfDepartmentFilterForm=this.createHeadOfDepartmentFilterForm();
    this.getAll();
    this.getAllAcademicYears();
    this.getAllAcademicLevels();
    this.getAllTeachers();
    this.getAllSubjects();
  }
  
  // search start

  setPage(pageInfo) {
    this.spinner.show();
    this.loadingIndicator = true;
    this.currentPage = pageInfo.offset;
    this.getHeadOfDepartmentList();
  }

   //FIlter Master 
   filterDatatable(event) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    const val = event.target.value.toLowerCase();
    this.spinner.show();
    this.getHeadOfDepartmentList();
  }

  getHeadOfDepartmentList(){
    this.loadingIndicator = true;
    this.headOfDepartmentService.getHeadOfDepartmentList(this.searchFilterdId, this.currentPage + 1, this.pageSize)
    .subscribe(response=>{
      this.data = response.data;
      this.totalRecord = response.totalRecordCount;
      this.spinner.hide();
      this.loadingIndicator = false;

    },error=>{
      this.spinner.hide();
      this.loadingIndicator = false;
      this.messageService.add({severity:'error', summary: 'Error', detail: 'Network error has been occured. Please try again.'});
    });
  }

  createHeadOfDepartmentFilterForm():FormGroup{

    return this.fb.group({
      searchText:new FormControl(""),
    })

  }

  get searchFilterdId(){
    return this.headOfDepartmentFilterForm.get("searchText").value;
  }

  //search end

  getAllAcademicYears()
  {
    this.headOfDepartmentService.getAllAcademicYears()
      .subscribe(response=>
      { this.academicYears = response;
      },error=>{
       });
  }

  getAllAcademicLevels()
  {
    this.headOfDepartmentService.getAllAcademicLevels()
      .subscribe(response=>
      { this.academicLevels = response;
      },error=>{
        });
  }

  getAllTeachers()
  {
    this.headOfDepartmentService.getAllTeachers()
      .subscribe(response=>
      { 
        this.teachers = response;
        },error=>{
          });
  }

  getAllSubjects()
  {
    this.headOfDepartmentService.getAllSubjects()
      .subscribe(response=>
      { this.subjects = response;
      },error=>{
       });
  }

  getAll()
  {
    this.loadingIndicator=true;
    this.headOfDepartmentService.getAll()
    .subscribe(response=>
    {
        this.data= response;
        this.loadingIndicator=false;
        console.log( response);
    },error=>{
      this.loadingIndicator=false;
        });
  }


  addNewHeadOfDepartment(content) {

    this.headOfDepartmentFrom = this.fb.group({
      id:[0],
      academicYearId: [null, [Validators.required]],
      academicLevelId: [null, [Validators.required]],
      teacherId: [null, [Validators.required]],
      subjectId: [null, [Validators.required]]
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });

  }

  saveHeadOfDepartment(){   
    
    console.log(this.headOfDepartmentFrom.value);
    
    this.headOfDepartmentService.saveHeadOfDepartment(this.headOfDepartmentFrom.value)
    .subscribe(response=>{

        if(response.isSuccess)
        {
          this.modalService.dismissAll();
          this.messageService.add({severity:'success', summary: 'Success', detail: response.message});
          this.getAll();
        }
        else
        {
          this.messageService.add({severity:'error', summary: 'error', detail: response.message});
        }

    },error=>{
      });

  }

  updateHeadOfDepartment(row:HeadOfDepartmentModel, rowIndex:number, content:any) {

    console.log(row);
    
    this.headOfDepartmentFrom = this.fb.group({
      id:[row.id],
      academicYearId: [row.academicYearId, [Validators.required]],
      academicLevelId: [row.academicLevelId, [Validators.required]],
      teacherId: [row.teacherId, [Validators.required]],
      subjectId: [row.subjectId, [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

    //delete Head Of Department
  deleteHeadOfDepartment(row) {
    Swal.fire({
      title: 'Are you sure Delete Head Of Department ?',
      showCancelButton: true,
      confirmButtonColor: 'red',
      cancelButtonColor: 'green',
      confirmButtonText: 'Yes',
    }).then((result) => {

      if (result.value) {

        this.headOfDepartmentService.delete(row.id).subscribe(response=>{

          if(response.isSuccess)
          {
            this.messageService.add({severity:'success', summary: 'Success', detail: response.message});
            this.getAll();
          }
          else
          {
            this.messageService.add({severity:'error', summary: 'error', detail: response.message});
          }
    
        },error=>{
         });
      }
    });
  }
  
    

}
