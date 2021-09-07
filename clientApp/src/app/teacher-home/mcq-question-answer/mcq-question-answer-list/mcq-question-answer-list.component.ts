import  Swal  from 'sweetalert2';
import { McqQuestionAnswerService } from './../../../services/mcq-question-answer/mcq-question-answer.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-mcq-question-answer-list',
  templateUrl: './mcq-question-answer-list.component.html',
  styleUrls: ['./mcq-question-answer-list.component.sass'],
  providers: [ToastrService],
})

export class McqQuestionAnswerListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: 
    DatatableComponent;
    data = [];
    scrollBarHorizontal = window.innerWidth < 1200;
    loadingIndicator = false;
    reorderable = true;
    mcqQuestionAnswerForm: FormGroup;


  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private McqQuestionAnswerService : McqQuestionAnswerService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.getAll();
  }

  //retrive method
  getAll(){
    this.loadingIndicator = true;
    this.McqQuestionAnswerService.getAll().subscribe(response => {
      this.data=response;
      this.loadingIndicator = false;

    }, error =>{
      this.loadingIndicator = false;
      this.toastr.error("Network error has been occured!, Please try again", "Error")
    })
   }


   //add new question using form
  createNewMcqQuestionAnswer(content)
  {
    this.mcqQuestionAnswerForm = this.fb.group({
      questionid:['', [Validators.required]],
      answertext:['', [Validators.required]],
      modifieddate:['', [Validators.required]],
      createdon:['', [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

  //delete method
  deleteClass(row) {
    Swal.fire({
      title: 'Are you sure Delete Class ?',
      showCancelButton: true,
      confirmButtonColor: 'red',
      cancelButtonColor: 'green',
      confirmButtonText: 'Yes',
    }).then((result) => {
      if (result.value) {
        this.McqQuestionAnswerService.delete(row.id).subscribe(response=>{
        
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


  //save MCQ Student Answer button 
  saveMcqStudentAnswer()
  {
    console.log(this.mcqQuestionAnswerForm.value);

    this.McqQuestionAnswerService.saveMcqQuestionAnswer(this.mcqQuestionAnswerForm.value)
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
