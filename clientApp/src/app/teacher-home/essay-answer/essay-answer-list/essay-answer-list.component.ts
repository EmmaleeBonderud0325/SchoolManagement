import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-essay-answer-list',
  templateUrl: './essay-answer-list.component.html',
  styleUrls: ['./essay-answer-list.component.sass'],
  providers: [ToastrService],

})
export class EssayAnswerListComponent implements OnInit {
  
  @ViewChild(DatatableComponent, { static: false }) table: 
    DatatableComponent;
    data = [];
    scrollBarHorizontal = window.innerWidth < 1200;
    loadingIndicator = false;
    reorderable = true;
    essayAnswerForm: FormGroup;

    
  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {

    this.getAll();
    this.essayAnswerForm = this.fb.group({
        //questionText:['', Validators.required],
        //marks:['', Validators.required],
         });
  }
  getAll() {}
 
  saveEssayQuestionAnswer(content){
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
    this.toastr.success('SUCCESS', '');
  }
  }

