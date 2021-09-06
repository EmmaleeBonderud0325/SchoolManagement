import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EssayQuestionAnswerService} from './../../../services/essay-answer/essay-answer.service';
import { ToastrService } from 'ngx-toastr';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import Swal from 'sweetalert2';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { EssayQuestionAnswerModel } from 'src/app/models/essay-answer/essay.answer.model';

@Component({
  selector: 'app-essay-answer-list',
  templateUrl: './essay-answer-list.component.html',
  styleUrls: ['./essay-answer-list.component.sass'],
  providers: [ToastrService]

})
export class EssayAnswerListComponent implements OnInit {
  
  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
    data = [];
    scrollBarHorizontal = window.innerWidth < 1200;
    loadingIndicator = false;
    reorderable = true;
    essayAnswerForm: FormGroup;
    questionNames:DropDownModel[] = [];

    
  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private toastr: ToastrService,
    private EssayQuestionAnswerService : EssayQuestionAnswerService
  ) { }

  ngOnInit(): void {

    this.getAll();
    this.getAllQuestions();
  
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
             
           },error=>{
             this.toastr.error("Network error has been occured. Please try again.","Error");
            });
       }

  //update
  editRow(row:EssayQuestionAnswerModel, rowIndex:number, content) 
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