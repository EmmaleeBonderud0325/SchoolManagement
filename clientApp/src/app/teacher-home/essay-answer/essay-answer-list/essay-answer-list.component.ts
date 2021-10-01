import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EssayQuestionAnswerService} from './../../../services/essay-answer/essay-answer.service';
import { ToastrService } from 'ngx-toastr';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import Swal from 'sweetalert2';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { EssayQuestionAnswerModel } from 'src/app/models/essay-answer/essay.answer.model';
import { NgxSpinnerService } from 'ngx-spinner';
import { BasicEssayQuestionAnswerModel } from 'src/app/models/essay-answer/basic.essay.answer.model';

@Component({
  selector: 'app-essay-answer-list',
  templateUrl: './essay-answer-list.component.html',
  styleUrls: ['./essay-answer-list.component.sass'],
  providers: [ToastrService]

})
export class EssayAnswerListComponent implements OnInit {
  
  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
    
    scrollBarHorizontal = window.innerWidth < 1200;
    loadingIndicator = false;
    reorderable = true;
    essayAnswerForm: FormGroup;
    questionNames:DropDownModel[] = [];
    EssayAnswerFilterForm:FormGroup;

  currentPage:number=0;
  pageSize:number = 25;
  totalRecord:number=0;

  data = new Array<BasicEssayQuestionAnswerModel>();
    
  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private toastr: ToastrService,
    private EssayQuestionAnswerService : EssayQuestionAnswerService,
    private spinner: NgxSpinnerService,
  ) { }

  ngOnInit(): void {

   
    this.getAllQuestions();
    this.EssayAnswerFilterForm = this.createFilterForm();
  
  }

  createNewEssayanswer(content)
      {
        this.essayAnswerForm = this.fb.group({
          id:[0],
          questionId:[null , [Validators.required]],
          answerText:['', [Validators.required]],
         

        });
    
        this.modalService.open(content, {
          ariaLabelledBy: 'modal-basic-title',
          size: 'lg',
        });
      }
    

         //User Filter data
     createFilterForm():FormGroup{

      return this.fb.group({

     searchText: new FormControl(""),
     questionId : new FormControl(0),
    

   })
 }

      filterDatatable(event) {
        this.currentPage = 0;
        this.pageSize = 25;
        this.totalRecord = 0;
        const val = event.target.value.toLowerCase();
        this.spinner.show();
        this.getQuestionList();
      }
      onQuestionFilterChanged(item: any) {
        this.currentPage = 0;
        this.pageSize = 25;
        this.totalRecord = 0;
        this.spinner.show();
        this.getQuestionList();
      }
      

       //Get paginated Details
       getQuestionList()
   {
      this.loadingIndicator =true;
      this.EssayQuestionAnswerService.getQuestionList(this.searchTextFilterId, this.currentPage + 1, this.pageSize, this.questionFilterId)
      .subscribe(response=>{
        this.data = response.data;

        console.log("==============");
        console.log(response);
        
        this.totalRecord = response.totalRecordCount;
        this.spinner.hide();
        this.loadingIndicator = false;
      },erroe=>{
        this.spinner.hide();
        this.loadingIndicator = false;
        this.toastr.error("Network error has been occured. Please try again.", "Error");
      });
   } 

       //getters 
       get questionFilterId()
       {
         return this.EssayAnswerFilterForm.get("questionId").value;
       }
 
       get searchTextFilterId() {
 
         return this.EssayAnswerFilterForm.get("searchText").value;
     
       }  

       setPage(pageInfo) {
        this.spinner.show();
        this.loadingIndicator = true;
        this.currentPage = pageInfo.offset;
        this.getQuestionList();
    
      }
 
    //get all
    getAll(){

        this.loadingIndicator = true;

        this.EssayQuestionAnswerService.getAll().subscribe(response => {

          this.data=response;
          this.loadingIndicator = false;
        }, error =>{

          this.loadingIndicator = false;
          this.toastr.error("Network error has been occured!, Please try again", "Error")
        })

       }
      //get all questions
getAllQuestions()
  {
    this.EssayQuestionAnswerService.getAllQuestions()
      .subscribe(response=>
        { 
          this.questionNames = response;
          console.log(response);
          this.getQuestionList();
             
        },error=>{
          this.toastr.error("Network error has been occured. Please try again.","Error");
          this.spinner.hide();
        });
       }

  //update
editRow(row:EssayQuestionAnswerModel, rowIndex:number, content:any) 
  {

    console.log(row);

    this.essayAnswerForm = this.fb.group({
      id:[row.id],
      questionId:[row.questionId, [Validators.required]],
      answerText:[row.answerText, [Validators.required]],
      
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }
 
onAddRowSave(form: FormGroup) {
    this.data.push(form.value);
    this.data = [...this.data];
    form.reset();
    this.modalService.dismissAll();
    this.addRecordSuccess();
  }
 
 //delete essayAnswer
deleteEssayAnswer(row) {
  Swal.fire({
    title: 'Are you sure Delete Essay Answer ?',
    showCancelButton: true,
    confirmButtonColor: 'red',
    cancelButtonColor: 'green',
    confirmButtonText: 'Yes',
  }).then((result) => {
    if (result.value) {

      this.EssayQuestionAnswerService.delete(row.id).subscribe(response=>{

        if(response.isSuccess)
        {
          this.toastr.success(response.message,"Success");
          this.getAll();
        }
       
  
      },error=>{
        this.toastr.error("Network error has been occured. Please try again.","Error");
      });
    }
  });
}

 //add a record
addRecordSuccess() {
    this.toastr.success('SUCCESS', '');
  }


   //save essay answer
saveEssayQuestionAnswer(){   
    
    console.log(this.essayAnswerForm.value);
    
    this.EssayQuestionAnswerService.saveEssayQuestionAnswer(this.essayAnswerForm.value)
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
      this.toastr.error("Network error has been occured. Please try again.","Error");
    });
  }

}