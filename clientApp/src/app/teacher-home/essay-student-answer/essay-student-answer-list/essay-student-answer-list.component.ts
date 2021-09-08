import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import {​​​​​​​​ FormGroup, FormBuilder, Validators }​​​​​​​​ from'@angular/forms';
import {​​​​​​​​ DatatableComponent }​​​​​​​​ from'@swimlane/ngx-datatable';
import {​​​​​​​​ Component, OnInit, ViewChild }​​​​​​​​ from'@angular/core';
import {EssayStudentAnswerService} from './../../../services/essay-student-answer/essay-student-answer.service';
import Swal from 'sweetalert2';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { EssayStudentAnswerModel } from 'src/app/models/essay-student-answer/essay.student.answer.model';


@Component({
  selector: 'app-essay-student-answer-list',
  templateUrl: './essay-student-answer-list.component.html',
  styleUrls: ['./essay-student-answer-list.component.sass'],
  providers: [ToastrService],
})
export class EssayStudentAnswerListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  essayStudentAnswerForm:FormGroup;
  reorderable = true;
  questionNames:DropDownModel[] = [];
  studentNames:DropDownModel[] = [];
  essayQuestionAnswerNames:DropDownModel[] = [];

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private EssayStudentAnswerService:EssayStudentAnswerService ,
    private toastr: ToastrService) { }

    ngOnInit(): void {
      this.getAll();
      this.getAllQuestions();
      this.getAllStudents();
      this.getAllEssayQuestionAnswers();
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
          
        },error=>{
          this.toastr.error("Network error has been occured. Please try again.","Error");
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
          
        },error=>{
          this.toastr.error("Network error has been occured. Please try again.","Error");
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

