import { Router } from '@angular/router';
import { BasicLessonModel } from './../../../models/lesson/basic.class.model';
import { NgxSpinnerService } from 'ngx-spinner';
import { Content } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit, ViewChild } from '@angular/core';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DatatableComponent, id } from '@swimlane/ngx-datatable';
import { ToastrService } from 'ngx-toastr';
import { LessonModel } from 'src/app/models/lesson/lesson.model';
import { LessonFilterModel } from 'src/app/models/lesson/lesson.filter.model';
import Swal from 'sweetalert2';
import { LessonService } from './../../../services/lesson/lesson.service';


@Component({
  selector: 'app-lesson-list',
  templateUrl: './lesson-list.component.html',
  styleUrls: ['./lesson-list.component.sass'],
  providers: [ToastrService],
})
export class LessonListComponent implements OnInit {
  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;

  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  lessonForm:FormGroup;
  lessonFilterForm:FormGroup;
  lesson:LessonModel;
  lessonFilter:LessonFilterModel;
  lessondesignAcademicLevels:DropDownModel[]=[];
  lessondesignAcademicYears:DropDownModel[]=[];
  lessondesignSubjects:DropDownModel[]=[];
  lessondesignClassNames:DropDownModel[]=[];
  reorderable = true;

  date:Date;

  
  currentPage: number = 0;
  pageSize: number = 25;
  totalRecord: number = 0;

  academicLevels:DropDownModel[] = [];
  classNames :DropDownModel[] = [];
  academicYears :DropDownModel[]=[];
  subjects :DropDownModel[]=[];

  data = new Array<BasicLessonModel>();

  constructor(
    private fb:FormBuilder,
    private modalService:NgbModal,
    private lessonService:LessonService,
    private toastr:ToastrService, 
    private spinner: NgxSpinnerService,
    private router:Router,
    ) {
      this.date= new Date();
     }

  ngOnInit(): void {
    //this.getAllLesson();
    this.lessonFilterForm = this.createLessonFilterForm(); 
    this.getMasterData();
   // this.getAllLessonList();
  }

  

  setPage(pageInfo) {
    this.spinner.show();
    this.loadingIndicator = true;
    this.currentPage = pageInfo.offset;
    this.getAllLessonList();
  }

  filterDatatable(event) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    const val = event.target.value.toLowerCase();
    this.spinner.show();
    this.getAllLessonList();
  }

  //filter onchanged Master filter data
  onAcademicYearFilterChanged(item: any) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    this.spinner.show();
    this.getAllLessonList();
  }
  onAcademicLevelFilterChanged(item: any) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    this.spinner.show();
    this.getAllLessonList();
  }
  onClassNameFilterChanged(item: any) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    this.spinner.show();
    this.getAllLessonList();
  }
  onSubjectIdFilterChanged(item: any) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    this.spinner.show();
    this.getAllLessonList();
  }

 
  //FIlter Master 
  
  //get Master DropDown Meta Data
  getMasterData() {
    this.lessonService.getLessonMasterData()
      .subscribe(response => {
        this.classNames = response.classNames;
        this.academicYears = response.academicYears;
        this.academicLevels = response.academicLevels;
        this.subjects = response.subjects;
        this.getAllLessonList();

      }, error => {
        this.spinner.hide();
      });
  }
  //getLessonList
  getAllLessonList()
  {
    this.loadingIndicator = true;
    this.lessonService.getAllLessonList(this.searchTextFilterData, this.academicYearFilterId,this.academicLevelFilterId,
                                               this.classNameFilterId,this.subjectFilterId, this.currentPage + 1,this.pageSize)
      .subscribe(response=>{
        console.log("Table Data");
        console.log(response);
        this.data = response.data;
        this.totalRecord = response.totalRecordCount;
        this.spinner.hide();
        this.loadingIndicator = false;
      },error=>{

        this.spinner.hide();
        this.loadingIndicator = false;
        this.toastr.error("Network error has been occured. Please try again.", "Error");
      });
  }
  
   //add new lesson using form
   createNewLesson(content)
   {
     this.lessonForm = this.fb.group({
      id:[0],
       name:['', [Validators.required]],
       description:['', [Validators.required]],
       academicLevelId:[null, [Validators.required]],
       classNameId:[null, [Validators.required]],
       academicYearId:[null, [Validators.required]],
       subjectId:[null, [Validators.required]],
       learningOutcome:['', [Validators.required]],
       plannedDate:['', [Validators.required]],
       
   });
 
     this.modalService.open(content, {
       ariaLabelledBy: 'modal-basic-title',
       size: 'lg',
     });
   }
  
  saveLesson()
  {
  
      this.spinner.show();
      var lessonModel = this.lessonForm.getRawValue();
      console.log("++++++++++++++++++++++++++++++++=");
      
      console.log(this.lessonForm.value);
      
      this.lessonService.saveLesson(lessonModel).subscribe(response=>{
        this.spinner.hide();
        if(response.isSuccess)
        {
          this.modalService.dismissAll();
          this.toastr.success(response.message,"Success");
          //this.getAll();
        }
        else
        {
          this.toastr.error(response.message,"Errror");
        }
      },error=>{
        this.spinner.hide();
        this.toastr.error("Network error has been occured. Please try again.", "Error");
      });
  

  }

  createLessonFilterForm() : FormGroup{

    return new FormGroup({
      searchText:new FormControl(""),
      academicYearId:new FormControl(0),
      academicLevelId:new FormControl(0),
      classNameId:new FormControl(0),
      subjectId:new FormControl(0)

    });
  }

  deleteLesson(row){
    
      Swal.fire({
      title: 'Are you sure to Delete Lesson ?',
      showCancelButton: true,
      confirmButtonColor: 'red',
      cancelButtonColor: 'green',
      confirmButtonText: 'Yes',
       }).then((result) => {

        if (result.value) {

          this.lessonService.delete(row.id).subscribe(response=>{
            if(response.isSuccess)
           {
              this.toastr.success(response.message,"Success");
              this.getAllLessonList()
            }
           else
            {
              this.toastr.error(response.message,"Error");
            }
       
           }  ,error=>{
              this.toastr.error("Network error has been occured. Please try again.","Error");
           });
          }
       });   
  }

  updateLesson(row:LessonModel,rowIndex:number,content:any){

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });

  }
  /* getAllLesson(){
      this.loadingIndicator = true;
      this.lessonService.getAllLesson(this.lessonFilterForm.getRawValue()).subscribe(response => {
      this.data = response;
      console.log(response);
      
      this.loadingIndicator = false;
      }, error =>{
     this.loadingIndicator = false;
     this.toastr.error("Network error has been occured!, Please try again", "Error")
      })  
     }
 */
  addNewLesson(content){

    this.lessonForm = this.fb.group({
      id:[0],
      name:['',[Validators.required]],
    })

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

 

  /* onAcademicYearFilterChanged(item:any)
  {
     this.lessonFilterForm.get("selectedAcademicLevelId").setValue(0);
  } */

  //list genarate
  get searchTextFilterData() {
    return this.lessonFilterForm.get("searchText").value;
  }
  get academicYearFilterId()
  {
    return this.lessonFilterForm.get("academicYearId").value;
  }

  get academicLevelFilterId()
  {
    return this.lessonFilterForm.get("academicLevelId").value;
  }

  get classNameFilterId()
  {
    return this.lessonFilterForm.get("classNameId").value;
  }

  get subjectFilterId()
  {
    return this.lessonFilterForm.get("subjectId").value;
  }

  //Routes
  addNewLessonRoute()
  {
    this.router.navigate(['/teacher-home/lesson/lesson-detail',0]);
  }
 
  
}


