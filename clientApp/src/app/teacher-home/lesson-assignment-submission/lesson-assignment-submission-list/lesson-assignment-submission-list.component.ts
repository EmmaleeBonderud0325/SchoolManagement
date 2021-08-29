import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-lesson-assignment-submission-list',
  templateUrl: './lesson-assignment-submission-list.component.html',
  styleUrls: ['./lesson-assignment-submission-list.component.sass'],
  providers: [ToastrService],
})
export class LessonAssignmentSubmissionListComponent implements OnInit {
  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  lessonAssignmentSubmissionForm:FormGroup;
  reorderable = true;

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.getAll();
    this.lessonAssignmentSubmissionForm = this.fb.group({
      questionText:['', Validators.required],
      marks:['', Validators.required],
    });
}



getAll(){ }

    saveLessonAssignment(content){
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
