import { StudentMcqQuestionAnswerModel } from './../../../models/student-mcq-question-answer/student-mcq-question-answer';
import Swal  from 'sweetalert2';
import { StudentMcqQuestionAnswerService } from './../../../services/student-mcq-question-answer/student-mcq-question-answer.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
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
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  reorderable = true;
  StudentMCQQuestionForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private StudentMcqQuestionAnswerService : StudentMcqQuestionAnswerService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.getAll();
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
  

  //add new question using form
  createStudentMCQQuestion(content)
  {
    this.StudentMCQQuestionForm = this.fb.group({
      questionName:['', [Validators.required]],
      studenName:['', [Validators.required]],
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
  editRow(row:StudentMcqQuestionAnswerModel, rowIndex:number, content) 
  {
    console.log(row);

    this.StudentMCQQuestionForm = this.fb.group({
      questionName:[row.questionId, [Validators.required]],
      studenName:[row.studentId, [Validators.required]],
      teacherComments:[row.teacherComments, [Validators.required]],
      marks:[row.marks, [Validators.required]],
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }


}
