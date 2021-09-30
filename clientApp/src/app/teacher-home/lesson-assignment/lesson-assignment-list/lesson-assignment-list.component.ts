import { HttpParams } from "@angular/common/http";
import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { DatatableComponent } from "@swimlane/ngx-datatable";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { DropDownModel } from "src/app/models/common/drop-down.model";
import { LessonAssignmentModel } from "src/app/models/lesson-assignment/lesson.assignment.model";
import Swal from "sweetalert2";
import {LessonAssignmentService} from './../../../services/lesson-assignment/lesson-assignment.service';
import { BasicLessonAssignmentModel } from "src/app/models/lesson-assignment/basic.lesson.assignment.model";


@Component({
  selector: 'app-lesson-assignment-list',
  templateUrl: './lesson-assignment-list.component.html',
  styleUrls: ['./lesson-assignment-list.component.sass'],
  providers: [ToastrService],
  
})
export class LessonAssignmentListComponent implements OnInit{

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  lessonAssignmentForm:FormGroup;
  reorderable = true;
  lessonNames:DropDownModel[] = [];
  lessonAssignmentFilterForm:FormGroup;

 

  currentPage:number=0;
  pageSize:number = 25;
  totalRecord:number=0;

  data = new Array<BasicLessonAssignmentModel>();
 
  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private LessonAssignmentService:LessonAssignmentService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
  ) { }

  ngOnInit(): void {
   
    this.getAllLessons();
    this.lessonAssignmentFilterForm = this.createFilterForm();
    
  }

  createNewLessonAssignment(content)
      {
        this.lessonAssignmentForm = this.fb.group({
          id:[0],
          lessonId:[null, [Validators.required]],
          name:['', [Validators.required]],
          description:['', [Validators.required]],
          startDate:['', [Validators.required]],
          duetDate:['', [Validators.required]],
         
          

        });
    
        this.modalService.open(content, {
          ariaLabelledBy: 'modal-basic-title',
          size: 'lg',
        });
      }

       //User Filter data
     createFilterForm():FormGroup{

       return this.fb.group({

      searchText: new FormControl(""),
      lessonId : new FormControl(0),
     

    })
  }

      filterDatatable(event) {
        this.currentPage = 0;
        this.pageSize = 25;
        this.totalRecord = 0;
        const val = event.target.value.toLowerCase();
        this.spinner.show();
        this.getLessonList();
      }
      onLessonFilterChanged(item: any) {
        this.currentPage = 0;
        this.pageSize = 25;
        this.totalRecord = 0;
        this.spinner.show();
        this.getLessonList();
      }

  

   //Get paginated Details
   getLessonList()
  {
     this.loadingIndicator =true;
     this.LessonAssignmentService.getLessonList(this.searchTextFilterId, this.currentPage + 1, this.pageSize, this.lessonFilterId)
        .subscribe(response=>{
          this.data = response.data;

          console.log("==============");
          console.log(response);
          
          this.totalRecord = response.totalRecordCount;
          this.spinner.hide();
          this.loadingIndicator = false;
        },erroe=>{
          this.spinner.hide();
          this.loadingIndicator = false;
          this.toastr.error("Network error has been occured. Please try again.", "Error");
        });
  } 
      //getters 
      get lessonFilterId()
      {
        return this.lessonAssignmentFilterForm.get("lessonId").value;
      }

      get searchTextFilterId() {

        return this.lessonAssignmentFilterForm.get("searchText").value;
    
      }  

      //retrieve
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
 

       setPage(pageInfo) {
        this.spinner.show();
        this.loadingIndicator = true;
        this.currentPage = pageInfo.offset;
        this.getLessonList();
    
      }

    //get all lesons
    getAllLessons()
    {
      this.LessonAssignmentService.getAllLessons()
        .subscribe(response=>
        { 
          this.lessonNames = response;
          console.log(response);
          this.getLessonList();
          
        },error=>{
          this.spinner.hide();
         });
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



 //save essay answer
 saveLessonAssignment(){   
    
      console.log(this.lessonAssignmentForm.value);
      
      this.LessonAssignmentService.saveLessonAssignment(this.lessonAssignmentForm.value)
      .subscribe(response=>{
  
          if(response.isSuccess)
          {
            this.modalService.dismissAll();
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
       
    //update
    editRow(row:LessonAssignmentModel, rowIndex:number, content:any) 
    {
  
      console.log(row);
  
      this.lessonAssignmentForm  = this.fb.group({
        id:[row.id],
        lessonId:[row.lessonId, [Validators.required]],
        name:[row.name, [Validators.required]],
        description:[row.description, [Validators.required]],
        startDate:[row.startDate, [Validators.required]],
        duetDate:[row.duetDate, [Validators.required]],
       
        
        
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
     
      

      addRecordSuccess() {
        this.toastr.success('SUCCESS', '');
      } 
    }