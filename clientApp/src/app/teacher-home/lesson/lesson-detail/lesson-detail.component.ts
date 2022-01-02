import { id } from '@swimlane/ngx-datatable';
import { ToastrService } from 'ngx-toastr';
import { BasicLessonModel } from './../../../models/lesson/basic.class.model';
import { LessonModel } from 'src/app/models/lesson/lesson.model';
import { NgxSpinnerService } from 'ngx-spinner';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DropdownService } from './../../../services/drop-down/dropdown.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroupDirective, FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { PrimeNGConfig } from 'primeng/api';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { LessonService } from 'src/app/services/lesson/lesson.service';

@Component({
  selector: 'lesson-detail',
  templateUrl: './lesson-detail.component.html',
  styles: ['::ng-deep .p-calendar .p-inputtext {flex: 0 0 auto;width: 100%;margin-top: -11px;    margin-left: -16px;margin-right: -16px;}'],
  providers: [ToastrService],
})
export class LessonDetailComponent implements OnInit {

  @Input() formGroupName: string;
  basicLessonForm: FormGroup;

  academicLevels:DropDownModel[]=[];
  academicYears:DropDownModel[]=[];
  subjects:DropDownModel[]=[];
  classNames:DropDownModel[]=[];
  lessonId:number=0;

  isDisable:boolean=false;


  constructor( private dropDownService:DropdownService,
    private lessonService:LessonService,
    private rootFormGroup: FormGroupDirective,
    private router: Router,
    private primengConfig: PrimeNGConfig,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private toastr: ToastrService,
    public activateRoute: ActivatedRoute,
    private spinner: NgxSpinnerService) {

      this.lessonService.onLessonDetailAssigned.subscribe(response=>{
          this.loadClasses();

      });

     }

  ngOnInit(): void {
    this.basicLessonForm = this.rootFormGroup.control.get(this.formGroupName) as FormGroup;
    this.spinner.show();
    this.loadMasterData();

    this.activateRoute.params.subscribe(params => {
      this.lessonId = +params.id;

      console.log(params.id);
     
    });
  }


  loadMasterData()
  {
      this.lessonService.getLessonMasterData().subscribe(response=>{
          this.academicYears = response.academicYears;
          this.academicLevels= response.academicLevels;
          this.classNames = this.classNames
          this.subjects = response.subjects;

          if(this.academicLevelFilterId && this.academicLevelFilterId>0)
          {
            this.loadClasses();
          }
          else
          {
            this.spinner.hide();
          }

      },error=>{
          this.spinner.hide();
      });
  }


  loadClasses()
  {
    this.dropDownService.getClasese(this.academicYearFilterId,this.academicLevelFilterId)
      .subscribe(response=>{
        
          this.classNames = response;

          if(this.classNameFilterId && this.classNameFilterId>0)
          {
            this.loadSubjects();
          }
          else
          {
            this.spinner.hide();
          }

      },error=>{
        this.spinner.hide();
      })
  }

  loadSubjects()
  {
    this.dropDownService.getSubjectsForSelectedClass(this.academicYearFilterId,this.academicLevelFilterId,this.classNameFilterId)
    .subscribe(response=>{
        this.subjects = response;
        this.spinner.hide();

    },error=>{
      this.spinner.hide();
    })
  }

  onAcademicLevelChanged(item:any)
  {
      this.spinner.show();
      this.loadClasses();
  }

  onClassNameChanged(item:any)
  {
    this.spinner.show();
    this.loadSubjects();
  }

  onSubjectChanged(item:any)
  {

  }


 
  saveLesson()
  {
    this.spinner.show();
    console.log(this.basicLessonForm.value);
    
    this.lessonService.saveLesson(this.basicLessonForm.value).subscribe(response=>{
        this.spinner.hide();

        if(response.isSuccess)
        {
           
           // this.messageService.add({severity:'success', summary: 'Success', detail: response.message});
           this.toastr.success(response.message,"Success");
           
        }
        else
        {
           //this.messageService.add({severity:'error', summary: 'Error', detail: response.message});
           this.toastr.error(response.message,"Error");
        }
    },error=>{
      this.toastr.error("Network error has been occured. Please try again.","Error");
    })
  }

  

  get academicYearFilterId()
  {
    return this.basicLessonForm.get("academicYearId").value;
  }
  get academicLevelFilterId()
  {
    return this.basicLessonForm.get("academicLevelId").value;
  }
  get classNameFilterId()
  {
    return this.basicLessonForm.get("classNameId").value;
  }
  get subjectFilterId()
  {
    return this.basicLessonForm.get("subjectId").value;
  }

}


