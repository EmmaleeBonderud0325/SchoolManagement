import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import {​​​​​​​​ FormGroup, FormBuilder, Validators }​​​​​​​​ from'@angular/forms';
import {​​​​​​​​ DatatableComponent }​​​​​​​​ from'@swimlane/ngx-datatable';
import {​​​​​​​​ Component, OnInit, ViewChild }​​​​​​​​ from'@angular/core';
import {LessonAssignmentSubmissionService} from './../../../services/lesson-assignment-submission/lesson-assignment-submission.service';
import Swal from 'sweetalert2';
import { LessonAssignmentSubmissionModule } from '../lesson-assignment-submission.module';
import { LessonAssignmentSubmissionModel } from 'src/app/models/lesson-assignment-submission/lesson.assignment.submission.model';
import { DropDownModel } from 'src/app/models/common/drop-down.model';


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
  studentNames:DropDownModel[] = [];
  lessonAssignmentNames:DropDownModel[] = [];
  

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private LessonAssignmentSubmissionService:LessonAssignmentSubmissionService,
    private toastr: ToastrService) { }

    ngOnInit(): void {
      this.getAll();
      this. getAllStudents();
      this.getAllLessonAssignments();
      }

      createNewLessonAssignmentSubmission(content)
      {
        this.lessonAssignmentSubmissionForm = this.fb.group({
          lessonAssignmentId:[null, [Validators.required]],
          studentId:[null, [Validators.required]],
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


         //get all lesons
     getAllStudents()
    {
      this.LessonAssignmentSubmissionService.getAllStudents()
        .subscribe(response=>
        { 
          this.studentNames = response;
          console.log(response);
          
        },error=>{
          this.toastr.error("Network error has been occured. Please try again.","Error");
         });
    }

          //get all lesons
      getAllLessonAssignments()
          {
            this.LessonAssignmentSubmissionService.getAllLessonAssignments()
              .subscribe(response=>
              { 
                this.lessonAssignmentNames = response;
                console.log(response);
                
              },error=>{
                this.toastr.error("Network error has been occured. Please try again.","Error");
               });
          }
 


       //save essay answer
  saveLessonAssignmentSubmission(){   
    
  console.log(this.lessonAssignmentSubmissionForm.value);
  
  this.LessonAssignmentSubmissionService .saveLessonAssignmentSubmission(this.lessonAssignmentSubmissionForm.value)
  .subscribe(response=>{

      if(response.isSuccess)
      {
        this.modalService.dismissAll();
        this.toastr.success(response.message,"Success");
        this.getAll();
      }
     /*  else
      {
        this.toastr.error(response.message,"Error");
      } */

  },error=>{
    this.toastr.error("Network error has been occured. Please try again.","Error");
  });
}
     
  //update
  editRow(row:LessonAssignmentSubmissionModel, rowIndex:number, content:any) 
  {

    console.log(row);

    this.lessonAssignmentSubmissionForm  = this.fb.group({
      lessonAssignmentId:[row.lessonAssignmentId, [Validators.required]],
      studentId:[row.studentId, [Validators.required]],
      submissionPath:[row.submissionPath, [Validators.required]],
      submissionDate:[row.submissionDate, [Validators.required]],
      teacherComments:[row.teacherComments, [Validators.required]],
      marks:[row.marks, [Validators.required]],
      
      
    });

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
