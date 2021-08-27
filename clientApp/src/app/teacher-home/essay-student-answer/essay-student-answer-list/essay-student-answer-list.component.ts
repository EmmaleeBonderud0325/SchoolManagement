import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import {​​​​​​​​ FormGroup, FormBuilder, Validators }​​​​​​​​ from'@angular/forms';
import {​​​​​​​​ DatatableComponent }​​​​​​​​ from'@swimlane/ngx-datatable';
import {​​​​​​​​ Component, OnInit, ViewChild }​​​​​​​​ from'@angular/core';


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
  

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    
    private toastr: ToastrService) { }

    ngOnInit(): void {
      this.getAll();
      this.essayStudentAnswerForm = this.fb.group({
        questionText:['', Validators.required],
        marks:['', Validators.required],
         });
      }
 
      getAll(){ }
 
      saveEssayStudentAnswer(content){
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
