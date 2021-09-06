import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import  Swal  from 'sweetalert2';
import { QuestionService } from './../../../services/question/question.service';
import { ToastrService } from 'ngx-toastr';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { DatatableComponent } from '@swimlane/ngx-datatable';
import { Component, OnInit, ViewChild } from '@angular/core';


@Component({
  selector: 'app-question-list',
  templateUrl: './question-list.component.html',
  styleUrls: ['./question-list.component.sass'],
  providers: [ToastrService],
})

export class QuestionListComponent implements OnInit {
 
    @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
    data = [];
    scrollBarHorizontal = window.innerWidth < 1200;
    loadingIndicator = false;
    reorderable = true;
    questionForm: FormGroup;
    lessonName :DropDownModel[] = [];

    constructor(
      private fb: FormBuilder,
      private modalService: NgbModal,
      private QuestionService : QuestionService,
      private toastr: ToastrService) { }


    ngOnInit(): void {
      this.getAll();
      this.getAllLessonName();
    }

    getAllLessonName(){
      this.QuestionService.getAllLessonName()
        .subscribe(response=>
        { 
          this.lessonName = response;
          console.log(response)           

        },error=>{
          this.toastr.error("Network error has been occured. Please try again.","Error");
         });
    }

    //retrive method
    getAll(){
      this.loadingIndicator = true;
      this.QuestionService.getAll().subscribe(response => {
      this.data=response;
      this.loadingIndicator = false;

      }, error =>{
        this.loadingIndicator = false;
        this.toastr.error("Network error has been occured!, Please try again", "Error")
       })
    }

    //add new question using form
    createNewQuestion(content)
    {
      this.questionForm = this.fb.group({
        lessonName:[null, [Validators.required]],
        topic:[null, [Validators.required]],
        sequenceno:['', [Validators.required]],
        marks:['', [Validators.required]],
        questiontext:['', [Validators.required]],
        questionlevel:['', [Validators.required]],
        questiontype:['',[Validators.required]],
      });
    
      this.modalService.open(content, {
        ariaLabelledBy: 'modal-basic-title',
        size: 'lg',
      });
    }

    //delete method
    deleteQuestion(row) {
       Swal.fire({
            title: 'Are you sure Delete Question?',
            showCancelButton: true,
            confirmButtonColor: 'red',
            cancelButtonColor: 'green',
            confirmButtonText: 'Yes',
          }).then((result) => {
            if (result.value) {
              this.QuestionService.delete(row.id).subscribe(response=>{

                if(response.isSuccess){
                  this.toastr.success(response.message,"Success");
                  this.getAll();
                }
                else{
                  this.toastr.error(response.message,"Error");
                }
        
            },error=>{
                this.toastr.error("Network error has been occured. Please try again.","Error");
              }); 
            }
          });
      }


      //save Question button 
      saveQuestion()
      {
        console.log(this.questionForm.value);

        this.QuestionService.saveQuestion(this.questionForm.value)
          .subscribe(response=>{
            
            if(response.isSuccess)
            {
                this.modalService.dismissAll();
                this.toastr.success(response.message,"Success");
                //this.getAll();
            }
            else
            {
                this.toastr.error(response.message,"Error");
            }
          },error=>{

                this.toastr.error("Network error has been occre.Please try again","Error");
          });
        
      }
    
}
