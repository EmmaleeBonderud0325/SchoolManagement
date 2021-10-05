import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import {​​​​​​​​ FormGroup, FormBuilder, Validators, FormControl }​​​​​​​​ from'@angular/forms';
import {​​​​​​​​ DatatableComponent }​​​​​​​​ from'@swimlane/ngx-datatable';
import {​​​​​​​​ Component, OnInit, ViewChild }​​​​​​​​ from'@angular/core';
import {EssayStudentAnswerService} from './../../../services/essay-student-answer/essay-student-answer.service';
import Swal from 'sweetalert2';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { EssayStudentAnswerModel } from 'src/app/models/essay-student-answer/essay.student.answer.model';
import { NgxSpinnerService } from 'ngx-spinner';
import { BasicEssayStudentAnswerModel } from 'src/app/models/essay-student-answer/basic.essay.student.answer.model';


@Component({
  selector: 'app-essay-student-answer-list',
  templateUrl: './essay-student-answer-list.component.html',
  styleUrls: ['./essay-student-answer-list.component.sass'],
  providers: [ToastrService],
})
export class EssayStudentAnswerListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
 
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  essayStudentAnswerForm:FormGroup;
  reorderable = true;
  questionNames:DropDownModel[] = [];
  studentNames:DropDownModel[] = [];
  essayQuestionAnswerNames:DropDownModel[] = [];
  EssayStudentAnswerFilterForm:FormGroup;

  currentPage:number=0;
  pageSize:number = 25;
  totalRecord:number=0;

  data = new Array<BasicEssayStudentAnswerModel>();

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private EssayStudentAnswerService:EssayStudentAnswerService ,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService) { }
    

    ngOnInit(): void {
      //this.getAll();
      this.getAllQuestions();
      this.getAllStudents();
      this.getAllEssayQuestionAnswers();
      this.EssayStudentAnswerFilterForm = this.createFilterForm();

      }
    
    //create essay answer
      createNewEssayStudentanswer(content)
      {
        this.essayStudentAnswerForm = this.fb.group({
          questionId:[null, [Validators.required]],
          studentId:[null, [Validators.required]],
          essayQuestionAnswerId:[null, [Validators.required]],
          answerText:['', [Validators.required]],
          teacherComments:['', [Validators.required]],
          marks:['', [Validators.required]],

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
     studentId: new FormControl(0)
    

   });
 }
      filterDatatable(event) {
        this.currentPage = 0;
        this.pageSize = 25;
        this.totalRecord = 0;
        const val = event.target.value.toLowerCase();
        this.spinner.show();
        this.getStudentEssayList();
        
      }
      onQuestionFilterChanged(item: any) {
        this.currentPage = 0;
        this.pageSize = 25;
        this.totalRecord = 0;
        this.spinner.show();
        this.getStudentEssayList();
      }
      onStudentFilterChanged(item: any) {
        this.currentPage = 0;
        this.pageSize = 25;
        this.totalRecord = 0;
        this.spinner.show();
        this.getStudentEssayList();
      }

       //Get paginated Details
    getStudentEssayList()
  {
     this.loadingIndicator =true;
     this.EssayStudentAnswerService.getStudentEssayList(this.searchTextFilterId, this.currentPage + 1, this.pageSize, this.questionFilterId,this.studentFilterId)
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
        return this.EssayStudentAnswerFilterForm.get("questionId").value;
      }
        //getters 
        get studentFilterId()
        {
          return this.EssayStudentAnswerFilterForm.get("studentId").value;
        }

      get searchTextFilterId() {

        return this.EssayStudentAnswerFilterForm.get("searchText").value;
    
      }  

      setPage(pageInfo) {
       this.spinner.show();
       this.loadingIndicator = true;
       this.currentPage = pageInfo.offset;
       this.getStudentEssayList();
     
   
     }

    
      //get all
      getAll(){

        this.loadingIndicator = true;

        this.EssayStudentAnswerService .getAll().subscribe(response => {

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
      this.EssayStudentAnswerService.getAllQuestions()
        .subscribe(response=>
        { 
          this.questionNames = response;
          console.log(response);
          this.getStudentEssayList();
         
          
        },error=>{
          this.toastr.error("Network error has been occured. Please try again.","Error");
          this.spinner.hide();
         });
    }
   
    //get all students
    getAllStudents()
    {
      this.EssayStudentAnswerService.getAllStudents()
        .subscribe(response=>
        { 
          this.studentNames = response;
          console.log(response);
          this.getStudentEssayList();
          
        },error=>{
          this.toastr.error("Network error has been occured. Please try again.","Error");
          this.spinner.hide();
         });
    }

    //get all essay questions
    getAllEssayQuestionAnswers()
    {
      this.EssayStudentAnswerService.getAllEssayQuestionAnswers()
        .subscribe(response=>
        { 
          this.essayQuestionAnswerNames = response;
          console.log(response);
          
        },error=>{
          this.toastr.error("Network error has been occured. Please try again.","Error");
         });
    }
    //save essay answer
    saveEssayStudentAnswer(){   
    
    console.log(this.essayStudentAnswerForm.value);
    
    this.EssayStudentAnswerService.saveEssayStudentAnswer(this.essayStudentAnswerForm.value)
    .subscribe(response=>{

        if(response.isSuccess)
        {
          this.modalService.dismissAll();
          this.toastr.success(response.message,"Success");
          this.getAll();
        }
       /*  else
        {
          this.toastr.error(response.message,"Error");
        } */

    },error=>{
      this.toastr.error("Network error has been occured. Please try again.","Error");
    });
  }
     
  //update
  editRow(row:EssayStudentAnswerModel, rowIndex:number, content:any) 
  {

    console.log(row);

    this.essayStudentAnswerForm  = this.fb.group({
      questionId:[row.questionId, [Validators.required]],
      studentId:[row.studentId, [Validators.required]],
      essayQuestionAnswerId:[row.essayQuestionAnswerId, [Validators.required]],
      answerText:[row.answerText, [Validators.required]],
      teacherComments:[row.teacherComments, [Validators.required]],
      marks:[row.marks, [Validators.required]],
      
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }
 
  //onAdd row save
  onAddRowSave(form: FormGroup) {
        this.data.push(form.value);
        this.data = [...this.data];
        form.reset();
        this.modalService.dismissAll();
        this.addRecordSuccess();
      }
     
//delete essayStudent Answer
deleteStudentEssayAnswet(row) {
  Swal.fire({
    title: 'Are you sure Delete Essay Student Answer ?',
    showCancelButton: true,
    confirmButtonColor: 'red',
    cancelButtonColor: 'green',
    confirmButtonText: 'Yes',
  }).then((result) => {
    if (result.value) {

      this.EssayStudentAnswerService.delete(row.id).subscribe(response=>{

        if(response.isSuccess)
        {
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
  });
}
  
     
      addRecordSuccess() {
        this.toastr.success('SUCCESS', '');
      }
}
function subscribe(arg0: (response: any) => void, arg1: (error: any) => void) {
  throw new Error('Function not implemented.');
}

