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
    //user:questionModel;
    questionForm: FormGroup;

    constructor(
      private fb: FormBuilder,
      private modalService: NgbModal,
      private QuestionService : QuestionService,
      private toastr: ToastrService) { }


    ngOnInit(): void {
      this.getAll();
      this.questionForm = this.fb.group({
        questionText:['', Validators.required],
        marks:['', Validators.required],
         });
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

      getAll(){ }


      /* saveQuestion(content){
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
        this.toastr.success('succes', '');
      } */
}
