import { McqQuestionAnswerService } from './../../../services/mcq-question-answer/mcq-question-answer.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
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

  @ViewChild(DatatableComponent, { static: false }) table: 
    DatatableComponent;
    data = [];
    scrollBarHorizontal = window.innerWidth < 1200;
    loadingIndicator = false;
    reorderable = true;
    //user:questionModel;
    McqQuestionAnswerForm: FormGroup;


  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private McqQuestionAnswerService : McqQuestionAnswerService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.getAll();
    /* this.McqQuestionAnswerForm = this.fb.group({
        questionText:['', Validators.required],
        marks:['', Validators.required],
         }); */
  }

  //add new question using form
  createNewMcqQuestionAnswer(content)
  {
    this.McqQuestionAnswerForm = this.fb.group({
      /* lessonname:['', [Validators.required]],
      topic:['', [Validators.required]],
      sequenceno:['', [Validators.required]],
      marks:['', [Validators.required]],
      questiontext:['', [Validators.required]],
      questionlevel:['', [Validators.required]],
      questiontype:['',[Validators.required]], */
    });

    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    });
  }


  
  getAll() {}

  /* saveMcqQuestionAnswer(content){
    this.modalService.open(content, {
      ariaLabelledBy: 'modal-basic-title',
      size: 'lg',
    })
  }
 
  editRow(row, rowIndex, content) {
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
 
  deleteSingleRow(row) {
 
  }
 
  addRecordSuccess() {
    this.toastr.success('successful', '');
  } */


}
