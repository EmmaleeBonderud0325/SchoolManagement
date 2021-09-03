import { ClassModel } from './../../../models/class/class.model';
import { DropDownModel } from './../../../models/common/drop-down.model';
import { ToastrService } from 'ngx-toastr';
import { ClassService } from './../../../services/class/class.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { Component, OnInit, ViewChild } from '@angular/core';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-class-list',
  templateUrl: './class-list.component.html',
  styleUrls: ['./class-list.component.sass'],
  providers: [ToastrService],
})
export class ClassListComponent implements OnInit {

  @ViewChild(DatatableComponent, { static: false }) table: DatatableComponent;
  data = [];
  scrollBarHorizontal = window.innerWidth < 1200;
  loadingIndicator = false;
  saveClassForm:FormGroup;
  reorderable = true;
  class:ClassModel;
  classNames:DropDownModel[] = [];
  academicLavels:DropDownModel[] = [];
  academicYears:DropDownModel[] = [];
  classCategories:DropDownModel[] = [];
  languageStreams:DropDownModel[] = [];


  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private classService:ClassService,
    private toastr: ToastrService) { }

    ngOnInit(): void {
      this.getAll();
      this.getAllClassNames();
      this.getAllAcademicLevels();
      this.getAllAcademicYears();
      this.getAllClassCategories();
      this.getAllLanguageStreams();
    }

    getAllClassNames()
      {
        this.classService.getAllClassNames()
          .subscribe(response=>
          { 
            this.classNames = response;
          },error=>{
            this.toastr.error("Network error has been occured. Please try again.","Error");
           });
      }

    getAllAcademicYears()
    {
      this.classService.getAllAcademicYears()
        .subscribe(response=>
        { 
          this.academicYears = response;
        },error=>{
          this.toastr.error("Network error has been occured. Please try again.","Error");
         });
    }

  getAllAcademicLevels()
  {
    this.classService.getAllAcademicLevels()
      .subscribe(response=>
      { 
        this.academicLavels = response;
      },error=>{
        this.toastr.error("Network error has been occured. Please try again.","Error");
       });
  }

  getAllClassCategories()
  {
    this.classService.getAllClassCategories()
      .subscribe(response=>
      { 
        this.classCategories = response;
      },error=>{
        this.toastr.error("Network error has been occured. Please try again.","Error");
       });
  }

  getAllLanguageStreams()
  {
    this.classService.getAllLanguageStreams()
      .subscribe(response=>
      { 
        this.languageStreams = response;
      },error=>{
        this.toastr.error("Network error has been occured. Please try again.","Error");
       });
  }
  
  getAll()
  {
    this.loadingIndicator=true;
    this.classService.getAll()
    .subscribe(response=>
    {
        this.data= response;
        this.loadingIndicator=false;
    },error=>{
      this.loadingIndicator=false;
      this.toastr.error("Network error has been occured. Please try again.","Error");
    });
  }

    addNewClass(content) {

      this.saveClassForm = this.fb.group({
        name: ['', [Validators.required]],
        classNameId: [null, [Validators.required]],
        academicLevelId: [null, [Validators.required]],
        academicYearId: [null, [Validators.required]],
        classCategory: [null, [Validators.required]],
        languageStream: [null, [Validators.required]],
      });
  
      this.modalService.open(content, {
        ariaLabelledBy: 'modal-basic-title',
        size: 'lg',
      });
    }

    saveClass(){   
    
      console.log(this.saveClassForm.value);
      
      this.classService.saveClass(this.saveClassForm.value)
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
  
    onAddRowSave(form: FormGroup) {
      this.data.push(form.value);
      this.data = [...this.data];
      form.reset();
      this.modalService.dismissAll();
      this.addRecordSuccess();
    }

    editRow(row:ClassModel, rowIndex:number, content:any) {
      this.modalService.open(content, {
        ariaLabelledBy: 'modal-basic-title',
        size: 'lg',
      });

      this.saveClassForm = this.fb.group({
        name: [row.name, [Validators.required, Validators.pattern('[a-zA-Z]+')]],
        classNameId: [row.classNameId, [Validators.required]],
        academicLevelId: [row.academicLevelId, [Validators.required]],
        ademicYearId: [row.academicYearId, [Validators.required]],
        classCategory: [row.classCategory, [Validators.required]],
        languageStream: [row.languageStream, [Validators.required]],
      });
    }
  
//delete class
deleteClass(row) {
    Swal.fire({
      title: 'Are you sure Delete Class ?',
      showCancelButton: true,
      confirmButtonColor: 'red',
      cancelButtonColor: 'green',
      confirmButtonText: 'Yes',
    }).then((result) => {
      if (result.value) {

        this.classService.delete(row.id).subscribe(response=>{

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
      this.toastr.success('Class Add Successfully', '');
    }

}
