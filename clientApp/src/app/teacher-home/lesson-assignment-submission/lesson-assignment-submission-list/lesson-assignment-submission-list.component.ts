import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import {​​​​​​​​ FormGroup, FormBuilder, Validators }​​​​​​​​ from'@angular/forms';
import {​​​​​​​​ DatatableComponent }​​​​​​​​ from'@swimlane/ngx-datatable';
import {​​​​​​​​ Component, OnInit, ViewChild }​​​​​​​​ from'@angular/core';
import {LessonAssignmentSubmissionService} from './../../../services/lesson-assignment-submission/lesson-assignment-submission.service';
import Swal from 'sweetalert2';


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
    private LessonAssignmentSubmissionService:LessonAssignmentSubmissionService,
    private toastr: ToastrService) { }

    ngOnInit(): void {
      this.getAll();
      this.lessonAssignmentSubmissionForm = this.fb.group({
        questionText:['', Validators.required],
        marks:['', Validators.required],
         });
      }

      createNewLessonAssignmentSubmission(content)
      {
        this.lessonAssignmentSubmissionForm = this.fb.group({
          id:['', [Validators.required]],
          lessonAssignment:['', [Validators.required]],
          student:['', [Validators.required]],
          submissionPath:['', [Validators.required]],
          submissionDate:['', [Validators.required]],
          teacherComments:['', [Validators.required]],
          marks:['', [Validators.required]],

        });
    
        this.modalService.open(content, {
          ariaLabelledBy: 'modal-basic-title',
          size: 'lg',
        });
      }
 
      getAll(){

        this.loadingIndicator = true;

        this.LessonAssignmentSubmissionService .getAll().subscribe(response => {

          this.data=response;
          this.loadingIndicator = false;
        }, error =>{

          this.loadingIndicator = false;
          this.toastr.error("Network error has been occured!, Please try again", "Error")
        })

       }
 
 
      saveLessonAssignmentSubmission(content){
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
     
//delete lessonAssignment Submission
deleteLessonAssignmentuSubmission(row) {
  Swal.fire({
    title: 'Are you sure Delete Lesson Assignment Submission ?',
    showCancelButton: true,
    confirmButtonColor: 'red',
    cancelButtonColor: 'green',
    confirmButtonText: 'Yes',
  }).then((result) => {
    if (result.value) {

      this.LessonAssignmentSubmissionService.delete(row.id).subscribe(response=>{

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
