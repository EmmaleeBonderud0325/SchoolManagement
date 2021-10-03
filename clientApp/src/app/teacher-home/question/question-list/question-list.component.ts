import { questionModel } from './../../../models/question/question.model';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { NgxSpinnerService } from 'ngx-spinner';
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
    questionFilterForm:FormGroup;
    lessonNames :DropDownModel[] = [];
    topicNames :DropDownModel[] = [];

    currentPage: number = 0;
    pageSize: number = 25;
    totalRecord: number = 0;

    constructor(
      private fb: FormBuilder,
      private modalService: NgbModal,
      private QuestionService : QuestionService,
      private spinner: NgxSpinnerService,
      private toastr: ToastrService) { }


    ngOnInit(): void {
      this.getAllTopic();
      this.questionFilterForm = this.createQuestionFilterForm();
      
      this.getAllLessonName();
    
    }

    onQuestionFilterChanged(item: any) {
      this.currentPage = 0;
      this.pageSize = 25;
      this.totalRecord = 0;
      this.spinner.show();
      this.getLessonList();
    }

    filterDatatable(event) {
      this.currentPage = 0;
      this.pageSize = 25;
      this.totalRecord = 0;
      const val = event.target.value.toLowerCase();
      this.spinner.show();
      this.getLessonList();
    }
    setPage(pageInfo) {
      this.spinner.show();
      this.loadingIndicator = true;
      this.currentPage = pageInfo.offset;
      this.getLessonList();
    }
   

    //Get paginated Details
   getLessonList()
   {
      this.loadingIndicator =true;
      this.QuestionService.getLessonList(this.searchTextFilterId, this.currentPage + 1, this.pageSize, this.lessonFilterId)
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





  
    //display lesson name and topic
    getAllLessonName(){
      this.QuestionService.getAllLessonName()
        .subscribe(response=>
        { 
          this.lessonNames = response;
          console.log(response)           

        },error=>{
         
         });
    }

    getAllTopic() {
      this.QuestionService.getAllTopic()
      .subscribe(response=>
      { 
          this.topicNames = response;
          this.getLessonList();
          console.log(response)           

        },error=>{
          this.spinner.hide();
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
        id:[0],
        lessonId:[null, [Validators.required]],
        topicId:[null, [Validators.required]],
        sequenceNo:['', [Validators.required]],
        marks:['', [Validators.required]],
        questionText:['', [Validators.required]],
        //questionlevel:['', [Validators.required]],
        questionType :[1],
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


      
      createQuestionFilterForm(): FormGroup{
        return new FormGroup({
          searchText:new FormControl(""),
          lessonId:new FormControl(0),
        });
      }
       //getters
    get lessonFilterId(){
      return this.questionFilterForm.get("lessonId").value
    }

    get searchTextFilterId() {
      return this.questionFilterForm.get("searchText").value;
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

      //update button
      editRow(row:questionModel, rowIndex:number, content) 
      {
        console.log(row);
    
        this.questionForm = this.fb.group({
          id:[row.id],
          lessonId:[row.lessonId, [Validators.required]],
          topicId:[row.topicId, [Validators.required]],
          sequenceNo:[row.sequenceNo, [Validators.required]],
          marks:[row.marks, [Validators.required]],
          questionText:[row.questionText, [Validators.required]],
          questionType :[1],
          
        });
    
        this.modalService.open(content, {
          ariaLabelledBy: 'modal-basic-title',
          size: 'lg',
        });
      }
    
}
