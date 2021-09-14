import { BasicLessonModel } from './../../../models/lesson/basic.class.model';
import { NgxSpinnerService } from 'ngx-spinner';
import { DropDownModel } from './../../../models/common/drop-down.model';
import { Content } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit, ViewChild } from '@angular/core';
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
  reorderable = true;

  
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
    private spinner: NgxSpinnerService
    ) {
      this.lessonFilterForm = this.createLessonFilterForm();
     }

  ngOnInit(): void {

    //this.getAllLesson();
    this.getMasterData();
  
   
  }

  setPage(pageInfo) {
    this.spinner.show();
    this.loadingIndicator = true;
    this.currentPage = pageInfo.offset;
    //this.getAll();
  }
  //FIlter Master 
  filterDatatable(event) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    const val = event.target.value.toLowerCase();
    this.spinner.show();
    //this.getAll();
  }

  getMasterData() {
    console.log("===============");
    this.lessonService.getLessonMasterData()
      .subscribe(response => {
        console.log("===============");
        console.log(response);
        
        
        this.classNames = response.classNames;
        this.academicYears = response.academicYears;
        this.academicLevels = response.academicLevels;


        //this.getAll();

      }, error => {
        this.spinner.hide();
      });
  }
   //add new lesson using form
   createNewLesson(content)
   {
     this.lessonForm = this.fb.group({
       Id:['', [Validators.required]],
       name:['', [Validators.required]],
       learningoutcome:['', [Validators.required]],
       planneddate:['', [Validators.required]],
       completeddate:['', [Validators.required]],
       status:['', [Validators.required]],
   });
 
     this.modalService.open(content, {
       ariaLabelledBy: 'modal-basic-title',
       size: 'lg',
     });
   }
  
  saveLesson(content){
    {
      this.modalService.open(content, {
        ariaLabelledBy: 'modal-basic-title',
        size: 'lg',
      })
          
         
      
    }

  }

  createLessonFilterForm() : FormGroup{

    return new FormGroup({
      selectedAcademicYearId:new FormControl(0),
      selectedAcademicLevelId:new FormControl(0),
      selectedClassNameId:new FormControl(0),
      selectedSubjectId:new FormControl(0)

    });
  }

  delete(row){
    
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
              //this.getAllLesson();
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

  onAcademicYearFilterChanged(item:any)
  {
     this.lessonFilterForm.get("selectedAcademicLevelId").setValue(0);
  }

  //list genarate
  get slectedAcademicYearFilterId()
  {
    return this.lessonFilterForm.get("selectedAcademicLevelId").value;
  }
}


