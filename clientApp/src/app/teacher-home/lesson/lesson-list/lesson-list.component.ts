import { Content } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { ToastrService } from 'ngx-toastr';
import { LessonModel } from 'src/app/models/lesson/lesson.model';
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
  lesson:LessonModel;
  reorderable = true;

  constructor(
    private fb:FormBuilder,
    private modalService:NgbModal,
    private lessonService:LessonService,
    private toastr:ToastrService ) { }

  ngOnInit(): void {
    this.getAllLesson();
    this.delete(row);
   
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
       
       },error=>{
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
      this.lessonService.getAllLesson().subscribe(response => {
      this.lesson = response;
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
}
function row(row: any) {
  throw new Error('Function not implemented.');
}

