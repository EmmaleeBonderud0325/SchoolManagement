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
  getAll() {}
  

  //add new question using form
  createStudentMCQQuestion(content)
  {
    this.StudentMCQQuestionForm = this.fb.group({
      questionid:['', [Validators.required]],
      studentid:['', [Validators.required]],
      teachercomments:['', [Validators.required]],
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



}
