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
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  lessonForm:FormGroup;
  lessonFilterForm:FormGroup;
  lesson:LessonModel;
  lessonFilter:LessonFilterModel;
  reorderable = true;
 

  constructor(
    private fb:FormBuilder,
    private modalService:NgbModal,
    private lessonService:LessonService,
    private toastr:ToastrService ) { }

  ngOnInit(): void {
    this.getAllLesson();
    this.lessonFilterForm = this.createLessonFilterForm();
   
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
      selectedAcademicLevelId:new FormControl(0),
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
              this.getAllLesson();
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
  getAllLesson(){
      this.loadingIndicator = true;
      this.lessonService.getAllLesson(this.slectedAcademicYearFilterId).subscribe(response => {
      this.lesson = response;
      console.log(response);
      
      this.loadingIndicator = false;
      }, error =>{
     this.loadingIndicator = false;
     this.toastr.error("Network error has been occured!, Please try again", "Error")
      })  
     }

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


