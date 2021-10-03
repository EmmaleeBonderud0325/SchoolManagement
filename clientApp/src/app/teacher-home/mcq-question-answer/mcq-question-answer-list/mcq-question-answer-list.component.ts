import { BasicMCQQuestionAnswerModel } from './../../../models/mcq-question-answer/basic.mcqquestionanswer.model';
import { McqQuestionAnswerService } from './../../../services/mcq-question-answer/mcq-question-answer.service';
import { DropDownModel } from './../../../models/common/drop-down.model';
import { MCQQuestionAnswerModel } from './../../../models/mcq-question-answer/mcq-question-answer.model';
import { NgxSpinnerService } from 'ngx-spinner';
import  Swal  from 'sweetalert2';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
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

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
    
    scrollBarHorizontal = window.innerWidth < 1200;
    loadingIndicator = false;
    reorderable = true;
    mcqQuestionAnswerForm: FormGroup;
    questionStudentAnswerFilterForm: FormGroup;
    questionNames :DropDownModel[] = [];

    currentPage: number = 0;
    pageSize: number = 25;
    totalRecord: number = 0;

    data = new Array<BasicMCQQuestionAnswerModel>();


  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private McqQuestionAnswerService : McqQuestionAnswerService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
  ) { }

  ngOnInit(): void {
    //this.getAll();
    this.getAllQuestions();
    //this.getQuestionList();
    this.questionStudentAnswerFilterForm = this.createQuestionFilterForm();
  }

  onMcqQuestionAnswerFilterChanged(item: any) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    this.spinner.show();
    this.getQuestionList();
  }

  filterDatatable(event) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    const val = event.target.value.toLowerCase();
    this.spinner.show();
    this.getQuestionList();
  }

  setPage(pageInfo) {
    this.spinner.show();
    this.loadingIndicator = true;
    this.currentPage = pageInfo.offset;
    this.getQuestionList();
  }

  getQuestionList()
  {
     this.loadingIndicator =true;
     this.McqQuestionAnswerService.getQuestionList(this.searchTextFilterId, this.currentPage + 1, this.pageSize, this.questionFilterId)
        .subscribe(response=>{
          this.data = response.data;
          console.log(response);
          console.log("===========================");
          
          this.totalRecord = response.totalRecordCount;
          this.spinner.hide();
          this.loadingIndicator = false;
        },erroe=>{
          this.spinner.hide();
          this.loadingIndicator = false;
          this.toastr.error("Network error has been occured. Please try again.", "Error");
        });
  }

  createQuestionFilterForm(): FormGroup{
    return new FormGroup({
      searchText:new FormControl(""),
      questionId:new FormControl(0),
    });
  }
   //getters
get questionFilterId(){
  return this.questionStudentAnswerFilterForm.get("questionId").value
}

get searchTextFilterId() {
  return this.questionStudentAnswerFilterForm.get("searchText").value;
} 



  getAll(){
    this.loadingIndicator = true;
    this.McqQuestionAnswerService .getAll().subscribe(response => {
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
     this.McqQuestionAnswerService.getAllQuestions()
    .subscribe(response=>
    { 
        this.questionNames = response;
        console.log(response);
        this.getQuestionList();           

      },error=>{
        this.spinner.hide();
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

    this.McqQuestionAnswerService.saveMCQQuestionAnswer(this.mcqQuestionAnswerForm.value)
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
