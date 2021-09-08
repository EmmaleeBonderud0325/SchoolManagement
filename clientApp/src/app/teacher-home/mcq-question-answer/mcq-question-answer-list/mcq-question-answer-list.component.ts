import { DropDownModel } from './../../../models/common/drop-down.model';
import { MCQQuestionAnswerModel } from './../../../models/mcq-question-answer/mcq-question-answer.model';
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
    questionNames :DropDownModel[] = [];


  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private McqQuestionAnswerService : McqQuestionAnswerService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.getAll();
    //this.GetAllQuestion();
  }

  getAll(){
    this.loadingIndicator = true;
    this.McqQuestionAnswerService .getAll().subscribe(response => {
      this.data=response;
      this.loadingIndicator = false;

    }, error =>{
      this.loadingIndicator = false;
      this.toastr.error("Get all error has been occured!, Please try again", "Error")
    })
  }
  

  /* GetAllQuestion(){
    this.McqQuestionAnswerService.GetAllQuestion()
    .subscribe(response=>
    { 
        this.questionNames = response;
        console.log(response)           

      },error=>{
        this.toastr.error("Question is not generated. Please try again.","Error");
       });
  } */

  //retrive method
  /* getAll() {
    this.loadingIndicator = true;
      this.McqQuestionAnswerService.getAll().subscribe(response => {
      this.data=response;
      console.log(response)
      this.loadingIndicator = false;

      }, error =>{
        this.loadingIndicator = false;
        this.toastr.error("Get All method is not working, Please try again", "Error")
       })
  } */



   //add new question using form
  createNewMcqQuestionAnswer(content)
  {
    this.mcqQuestionAnswerForm = this.fb.group({
      questionId : [null, [Validators.required]],
      answerText : ['', [Validators.required]],
      isCorrectAnswer : ['', [Validators.required]],
      
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }

  //update button
  editRow(row:MCQQuestionAnswerModel, rowIndex:number, content : any) 
  {
    console.log(row);

    this.mcqQuestionAnswerForm = this.fb.group({
      questionId : [row.questionId, [Validators.required]],
      answerText : [row.answerText, [Validators.required]],
      isCorrectAnswer : [row.isCorrectAnswer, [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }


  //save MCQ Student Answer button 
  saveMcqQuestionAnswer()
  {
    console.log(this.mcqQuestionAnswerForm.value);

    this.McqQuestionAnswerService.saveMcqQuestionAnswer(this.mcqQuestionAnswerForm.value)
      .subscribe(response=>{
        
        if(response.isSuccess)
        {
            this.modalService.dismissAll();
            this.toastr.success(response.message,"Success");
            this.getAll();
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
