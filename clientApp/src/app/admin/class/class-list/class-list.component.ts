import { ClassSubjectModel } from './../../../models/class/class.subject.model';
import { DropdownService } from './../../../services/drop-down/dropdown.service';
import { ClassModel } from './../../../models/class/class.model';
import { DropDownModel } from './../../../models/common/drop-down.model';
import { ToastrService } from 'ngx-toastr';
import { ClassService } from './../../../services/class/class.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DatatableComponent } from '@swimlane/ngx-datatable';
import { Component, OnInit, ViewChild } from '@angular/core';
import Swal from 'sweetalert2';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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
  classSubjects:ClassSubjectModel[]=[];

  classNames:DropDownModel[] = [];
  academicLavels:DropDownModel[] = [];
  academicYears:DropDownModel[] = [];
  classCategories:DropDownModel[] = [];
  languageStreams:DropDownModel[] = [];
  classTeachers:DropDownModel[]=[];



  constructor(
    private fb: FormBuilder,
    private modalService: NgbModal,
    private classService:ClassService,
    private dropDownService:DropdownService,
    private toastr: ToastrService) { }

    ngOnInit(): void {
      this.getAll();
      this.getAllClassNames();
      this.getAllAcademicLevels();
      this.getAllAcademicYears();
      this.getAllClassCategories();
      this.getAllLanguageStreams(); 
    }
     //get class Names DropDown Meta Data
    getAllClassNames()
      {
        this.dropDownService.getAllClassNames()
          .subscribe(response=>
          { 
            this.classNames = response;
            console.log(response);
            
          },error=>{
           
           });
      }
    //get Academic Year DropDown Meta Data
    getAllAcademicYears()
      {
        this.dropDownService.getAllAcademicYears()
          .subscribe(response=>
          { 
            this.academicYears = response;
          },error=>{
            
          });
      }
    //get Academic Levels DropDown Meta Data
    getAllAcademicLevels()
    {
      this.dropDownService.getAllAcademicLevels()
        .subscribe(response=>
        { 
          this.academicLavels = response;
        },error=>{
         
        });
    }
    //get Class Categories DropDown Meta Data
    getAllClassCategories()
    {
      this.dropDownService.getAllClassCategories()
        .subscribe(response=>
        { 
          this.classCategories = response;
        },error=>{
          
        });
    }
    //get Language Streams DropDown Meta Data
    getAllLanguageStreams()
    {
      this.dropDownService.getAllLanguageStreams()
        .subscribe(response=>
        { 
          this.languageStreams = response;
        },error=>{
          this.toastr.error("Network error has been occured. Please try again.","Error");
        });
    } 
    //get teachers DropDown Meta Data
    getAllTeachers()
    {
      this.dropDownService.getAllTeachers()
        .subscribe(response=>
        {
            this.classTeachers = response;
        },error=>{

        });
    }

   //get Class
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
    //Add new Class Form
    addNewClass(content)
    {

      this.saveClassForm = this.fb.group({
        classNameId: [null, [Validators.required]],
        academicLevelId: [null, [Validators.required]],
        academicYearId: [null, [Validators.required]],
        name: ['', [Validators.required]],
        classCategory: [null, [Validators.required]],
        languageStream: [null, [Validators.required]],
        classTeacher:[null,[Validators.required]] 
      });
  
      this.modalService.open(content, {
        ariaLabelledBy: 'modal-basic-title',
        size: 'lg',
      });
    }
    //save Class
    saveClass()
    {   
    
      console.log(this.saveClassForm.value);
      
      //this.classService.saveClass(this.saveClassForm.value)
      this.classService.saveClass(this.saveClassForm.value)
      .subscribe(response=>{
          console.log("Hellow world")
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
    //Update Class    
    updateClass(row:ClassModel, rowIndex:number, content:any) 
    {
  
      console.log(row);
  
      this.saveClassForm = this.fb.group({
        selectclassNameId: [row.classNameId, [Validators.required]],
        selectacademicLevelId: [row.academicLevelId, [Validators.required]],
        selectacademicYearId: [row.academicYearId, [Validators.required]],
        selectclassCategory: [row.classCategory, [Validators.required]],
        selectlanguageStream: [row.languageStream, [Validators.required]],
      });

      this.modalService.open(content, {
        ariaLabelledBy: 'modal-basic-title',
        size: 'lg',
      });
    }
    //delete class
    deleteClass(row) 
    {
        Swal.fire({
          title: 'Are you sure Delete Class ?',
          showCancelButton: true,
          confirmButtonColor: 'red',
          cancelButtonColor: 'green',
          confirmButtonText: 'Yes',
        }).then((result) => {
          if (result.value) {

            this.classService.delete(row.classNameId).subscribe(response=>{

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

}
