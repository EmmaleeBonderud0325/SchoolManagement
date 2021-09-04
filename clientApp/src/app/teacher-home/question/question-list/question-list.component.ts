import  Swal  from 'sweetalert2';
import { QuestionService } from './../../../services/question/question.service';
import { ToastrService } from 'ngx-toastr';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
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

    constructor(
      private fb: FormBuilder,
      private modalService: NgbModal,
      private QuestionService : QuestionService,
      private toastr: ToastrService) { }


    ngOnInit(): void {
      this.getAll();
      }

      //add new question using form
      createNewQuestion(content)
      {
        this.questionForm = this.fb.group({
          lessonname:['', [Validators.required]],
          topic:['', [Validators.required]],
          sequenceno:['', [Validators.required]],
          marks:['', [Validators.required]],
          questiontext:['', [Validators.required]],
          questionlevel:['', [Validators.required]],
          questiontype:['',[Validators.required]],
        });
    
        this.modalService.open(content, {
          ariaLabelledBy: 'modal-basic-title',
          size: 'lg',
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

      //delete class
       deleteClass(row) {
          Swal.fire({
            title: 'Are you sure Delete Class ?',
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
                //this.getAll();
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
