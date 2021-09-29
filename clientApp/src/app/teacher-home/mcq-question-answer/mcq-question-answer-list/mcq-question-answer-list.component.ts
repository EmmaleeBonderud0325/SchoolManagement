import { McqQuestionAnswerService } from './../../../services/mcq-question-answer/mcq-question-answer.service';
import { DropDownModel } from './../../../models/common/drop-down.model';
import { MCQQuestionAnswerModel } from './../../../models/mcq-question-answer/mcq-question-answer.model';
import { NgxSpinnerService } from 'ngx-spinner';
import  Swal  from 'sweetalert2';
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
    questionStudentAnswerFilterForm: FormGroup;
    questionNames :DropDownModel[] = [];

    currentPage: number = 0;
    pageSize: number = 25;
    totalRecord: number = 0;


  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private mcqQuestionAnswerService : McqQuestionAnswerService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
  ) { }

  ngOnInit(): void {
    this.getAll();
    this.getAllQuestions();
  }

  onMcqQuestionAnswerFilterChanged(item: any) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    this.spinner.show();
    this.getAllQuestions();
  }

  filterDatatable(event) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    const val = event.target.value.toLowerCase();
    this.spinner.show();
    this.getAllQuestions();
  }

  getAll(){
    this.loadingIndicator = true;
    this.mcqQuestionAnswerService .getAll().subscribe(response => {
      console.log("init")
      this.data=response;
      console.log(response);
      this.loadingIndicator = false;

    }, error =>{
      this.loadingIndicator = false;
      this.toastr.error("Get all error has been occured!, Please try again", "Error")
    })
  }
  

 getAllQuestions(){
     this.mcqQuestionAnswerService.getAllQuestions()
    .subscribe(response=>
    { 
        this.questionNames = response;
        console.log(response)           

      },error=>{
        this.toastr.error("Question is not generated. Please try again.","Error");
       }); 
  } 

    //add new MCQ Question Answer using form
  createNewMCQQuestionAnswer(content)
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
  editRow(row:MCQQuestionAnswerModel, rowIndex:number, content) 
  {
    

    this.mcqQuestionAnswerForm = this.fb.group({
      id:[row.id],
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
  saveMCQQuestionAnswer()
  {
    console.log(this.mcqQuestionAnswerForm.value);

    this.mcqQuestionAnswerService.saveMCQQuestionAnswer(this.mcqQuestionAnswerForm.value)
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

            this.toastr.error("Save functions error has been occre.Please try again","Error");
      });
    }
}
