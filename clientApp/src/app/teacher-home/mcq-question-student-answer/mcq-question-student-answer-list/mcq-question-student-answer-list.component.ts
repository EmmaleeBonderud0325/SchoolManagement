import { McqQuestionStudentAnswerModel } from './../../../models/mcq-question-student-answer/mcq-question-student-answer.model';
import { DropDownModel } from './../../../models/common/drop-down.model';
import Swal  from 'sweetalert2';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { McqQuestionStudentAnswerService } from './../../../services/mcq-question-student-answer/mcq-question-student-answer.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DatatableComponent, id } from '@swimlane/ngx-datatable';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-mcq-question-student-answer-list',
  templateUrl: './mcq-question-student-answer-list.component.html',
  styleUrls: ['./mcq-question-student-answer-list.component.sass'],
  providers: [ToastrService],
})


export class McqQuestionStudentAnswerListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
    data = [];
    scrollBarHorizontal = window.innerWidth < 1200;
    loadingIndicator = false;
    reorderable = true;
    McqStudenAnswerForm: FormGroup;
    questionNames :DropDownModel[] = [];
    studentNames :DropDownModel[] = [];
    mCQQuestionAnswerNames :DropDownModel[] = [];


  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private McqQuestionStudentAnswerService : McqQuestionStudentAnswerService,
    private toastr: ToastrService) { }
  

  ngOnInit(): void {
    this.getAll();
    this.getAllQuestion();
    this.getAllStudentName();
    this.getAllTeacherAnswer();

  }

  //all dropdowns
  getAllQuestion(){
    this.McqQuestionStudentAnswerService.getAllQuestion()
      .subscribe(response=>
      { 
        this.questionNames = response;
        console.log(response)           

      },error=>{
        this.toastr.error("Network error has been occured. Please try again.","Error");
       });
  }

  getAllStudentName(){
    this.McqQuestionStudentAnswerService.getAllStudentName()
      .subscribe(response=>
      { 
        this.studentNames = response;
        console.log(response)           

      },error=>{
        this.toastr.error("Network error has been occured. Please try again.","Error");
       });
  }

  getAllTeacherAnswer(){
    this.McqQuestionStudentAnswerService.getAllTeacherAnswer()
      .subscribe(response=>
      { 
        this.mCQQuestionAnswerNames = response;
        console.log(response)           

      },error=>{
        this.toastr.error("Network error has been occured. Please try again.","Error");
       });
  }




  //retreve method
  getAll(){
    this.loadingIndicator = true;
    this.McqQuestionStudentAnswerService.getAll().subscribe(response => {
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
     this.McqStudenAnswerForm = this.fb.group({
       questionId:[null, [Validators.required]],
       studentId:[null, [Validators.required]],
       answerText:['', [Validators.required]],
       isChecked:['', [Validators.required]],
       
     });
   
     this.modalService.open(content, {
       ariaLabelledBy: 'modal-basic-title',
       size: 'lg',
     });
   }
   
  //update button
  editRow(row:McqQuestionStudentAnswerModel, rowIndex:number, content:any) 
  {
    console.log(row);

    this.McqStudenAnswerForm = this.fb.group({
      questionId:[row.questionId, [Validators.required]],
      studentId:[row.studentId, [Validators.required]],
      answerText:[row.answerText, [Validators.required]],
      isChecked:[row.isChecked, [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }


  //save essay answer
  saveMcqStudentAnswer(){   
    console.log(this.McqStudenAnswerForm.value);
    
    this.McqQuestionStudentAnswerService.saveMcqStudentAnswer(this.McqStudenAnswerForm.value)
    .subscribe(response=>{

        if(response.isSuccess)
        {
          this.modalService.dismissAll();
          this.toastr.success(response.message,"Success");
          this.getAll();
        }
        /* else
        {
          this.toastr.error(response.message,"Error");
        } */

    },error=>{
      this.toastr.error("Network error has been occured. Please try again.","Error");
    });
  }
}
