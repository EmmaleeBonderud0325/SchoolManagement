import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { DatatableComponent } from "@swimlane/ngx-datatable";
import { ToastrService } from "ngx-toastr";
import Swal from "sweetalert2";
import {LessonAssignmentService} from './../../../services/lesson-assignment/lesson-assignment.service';


@Component({
  selector: 'app-lesson-assignment-list',
  templateUrl: './lesson-assignment-list.component.html',
  styleUrls: ['./lesson-assignment-list.component.sass'],
  providers: [ToastrService],
  
})
export class LessonAssignmentListComponent implements OnInit{

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  lessonAssignmentForm:FormGroup;
  reorderable = true;

  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private LessonAssignmentService:LessonAssignmentService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {

    this.getAll();
      this.lessonAssignmentForm = this.fb.group({
        questionText:['', Validators.required],
        marks:['', Validators.required],
      });
  }

  createNewLessonAssignment(content)
      {
        this.lessonAssignmentForm = this.fb.group({
          id:['', [Validators.required]],
          lesson:['', [Validators.required]],
          name:['', [Validators.required]],
          description:['', [Validators.required]],
          isActive:['', [Validators.required]],
          createdOn:['', [Validators.required]],
          createdById:['', [Validators.required]],
          updatedOn:['', [Validators.required]],
          updatedById:['', [Validators.required]],

        });
    
        this.modalService.open(content, {
          ariaLabelledBy: 'modal-basic-title',
          size: 'lg',
        });
      }

      getAll(){

        this.loadingIndicator = true;

        this.LessonAssignmentService .getAll().subscribe(response => {

          this.data=response;
          this.loadingIndicator = false;
        }, error =>{

          this.loadingIndicator = false;
          this.toastr.error("Network error has been occured!, Please try again", "Error")
        })

       }
 

       //delete lessonAssignment
deleteLessonAssignment(row) {
  Swal.fire({
    title: 'Are you sure Delete Lesson Assignment ?',
    showCancelButton: true,
    confirmButtonColor: 'red',
    cancelButtonColor: 'green',
    confirmButtonText: 'Yes',
  }).then((result) => {
    if (result.value) {

      this.LessonAssignmentService.delete(row.id).subscribe(response=>{

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