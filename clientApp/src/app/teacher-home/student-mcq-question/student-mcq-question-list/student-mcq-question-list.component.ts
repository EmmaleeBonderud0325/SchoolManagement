import { BasicStudentMCQQuestionAnswerModel } from './../../../models/student-mcq-question-answer/basic.studentmcqquestionanswer.model';
import { DropDownModel } from './../../../models/common/drop-down.model';
import { StudentMcqQuestionAnswerModel } from './../../../models/student-mcq-question-answer/student-mcq-question-answer';
import { NgxSpinnerService } from 'ngx-spinner';
import Swal  from 'sweetalert2';
import { StudentMcqQuestionAnswerService } from './../../../services/student-mcq-question-answer/student-mcq-question-answer.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-student-mcq-question-list',
  templateUrl: './student-mcq-question-list.component.html',
  styleUrls: ['./student-mcq-question-list.component.sass'],
  providers: [ToastrService],
})

export class StudentMcqQuestionListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
 
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  reorderable = true;
  StudentMCQQuestionForm: FormGroup;
  studentMcqQuestionFilterForm:FormGroup;
  questionNames :DropDownModel[] = [];
  studentNames :DropDownModel[] = [];
  studentAnswerTexts :DropDownModel[] = []

  currentPage: number = 0;
  pageSize: number = 25;
  totalRecord: number = 0;

  data = new Array<BasicStudentMCQQuestionAnswerModel>();

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private StudentMcqQuestionAnswerService : StudentMcqQuestionAnswerService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
  ) { }
g
  ngOnInit(): void {
    //this.getAll();
    this.getAllQuestions();
    this.getAllStudentNames();
    this.getAllStudentAnswerTexts();

    this.studentMcqQuestionFilterForm = this.createStudentNameFilterForm();
  }

  onStudentMcqQuestionFilterChanged(item: any) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    this.spinner.show();
    this.getStudentNameList();
  }

  filterDatatable(event) {
    this.currentPage = 0;
    this.pageSize = 25;
    this.totalRecord = 0;
    const val = event.target.value.toLowerCase();
    this.spinner.show();
    this.getStudentNameList();
  }

  setPage(pageInfo) {
    this.spinner.show();
    this.loadingIndicator = true;
    this.currentPage = pageInfo.offset;
    this.getStudentNameList();
  }

  getStudentNameList()
   {
      this.loadingIndicator =true;
      this.StudentMcqQuestionAnswerService.getStudentNameList(this.searchTextFilterId, this.currentPage + 1, this.pageSize, this.studentNameFilterId)
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

   createStudentNameFilterForm(): FormGroup{
    return new FormGroup({
      searchText:new FormControl(""),
      studentId:new FormControl(0),
    });
  }
   //getters
  get studentNameFilterId(){
    return this.studentMcqQuestionFilterForm.get("studentId").value
  }

  get searchTextFilterId() {
    return this.studentMcqQuestionFilterForm.get("searchText").value;
  }



  getAll(){
    this.loadingIndicator = true;
    this.StudentMcqQuestionAnswerService.getAll().subscribe(response => {
      this.data=response;
      this.loadingIndicator = false;

    }, error =>{
      this.loadingIndicator = false;
      this.toastr.error("Get all method is not working!, Please try again", "Error")
    })
   }

  getAllQuestions() {
    this.StudentMcqQuestionAnswerService.getAllQuestions()
        .subscribe(response=>
        { 
          this.questionNames = response;
          console.log(response)           

        },error=>{
          this.toastr.error("Get Question error has been occured. Please try again.","Error");
         });
  }

  getAllStudentAnswerTexts() {
    this.StudentMcqQuestionAnswerService.getAllStudentAnswerTexts()
        .subscribe(response=>
        { 
          this.studentAnswerTexts = response;
          console.log(response)           

        },error=>{
          this.toastr.error("Get Question error has been occured. Please try again.","Error");
         });
  }

  getAllStudentNames() {
    this.StudentMcqQuestionAnswerService.getAllStudentNames()
        .subscribe(response=>
        { 
          this.studentNames = response;
          console.log(response)     
          this.getStudentNameList();      

        },error=>{
          this.spinner.hide();
          this.toastr.error("Get Student Names error has been occured. Please try again.","Error");
         });
  } 


  //add new question using form
  createStudentMCQQuestion(content)
  {
    this.StudentMCQQuestionForm = this.fb.group({
      questionId:[null, [Validators.required]],
      studentId:[null, [Validators.required]],
      teacherComments:['', [Validators.required]],
      marks:['', [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }


  //save Question button 
  saveStudentMCQQuestion()
  {
    console.log(this.StudentMCQQuestionForm.value);
    this.StudentMcqQuestionAnswerService.saveStudentMcqQuestionAnswer(this.StudentMCQQuestionForm.value)
      .subscribe(response=>{
        if(response.isSuccess)
        {
            this.modalService.dismissAll();
            this.toastr.success(response.message,"Success");
            this.getAll();
        }
      },error=>{

            this.toastr.error("Network error has been occre.Please try again","Error");
      });
    
  }

  //update button
  editRow(row:StudentMcqQuestionAnswerModel, rowIndex:number, content : any) 
  {
    console.log(row);

    this.StudentMCQQuestionForm = this.fb.group({
      questionId:[row.questionId, [Validators.required]],
      studentId:[row.studentId, [Validators.required]],
      teacherComments:[row.teacherComments, [Validators.required]],
      marks:[row.marks, [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }


}
