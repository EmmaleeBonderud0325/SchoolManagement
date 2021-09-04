import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import {​​​​​​​​ FormGroup, FormBuilder, Validators }​​​​​​​​ from'@angular/forms';
import {​​​​​​​​ DatatableComponent }​​​​​​​​ from'@swimlane/ngx-datatable';
import {​​​​​​​​ Component, OnInit, ViewChild }​​​​​​​​ from'@angular/core';
import {EssayStudentAnswerService} from './../../../services/essay-student-answer/essay-student-answer.service';
import Swal from 'sweetalert2';


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
    private EssayStudentAnswerService:EssayStudentAnswerService ,
    private toastr: ToastrService) { }

    ngOnInit(): void {
      this.getAll();
      this.essayStudentAnswerForm = this.fb.group({
        questionText:['', Validators.required],
        marks:['', Validators.required],
         });
      }

      createNewEssayStudentanswer(content)
      {
        this.essayStudentAnswerForm = this.fb.group({
          question:['', [Validators.required]],
          student:['', [Validators.required]],
          essayAnswer:['', [Validators.required]],
          answerText:['', [Validators.required]],
          teacherComments:['', [Validators.required]],
          tmarks:['', [Validators.required]],

        });
    
        this.modalService.open(content, {
          ariaLabelledBy: 'modal-basic-title',
          size: 'lg',
        });
      }
 
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
