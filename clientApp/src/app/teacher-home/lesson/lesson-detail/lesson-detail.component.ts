import { NgxSpinnerService } from 'ngx-spinner';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DropdownService } from './../../../services/drop-down/dropdown.service';
import { Router } from '@angular/router';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroupDirective, FormBuilder, FormGroup } from '@angular/forms';
import { PrimeNGConfig } from 'primeng/api';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { LessonService } from 'src/app/services/lesson/lesson.service';

@Component({
  selector: 'lesson-detail',
  templateUrl: './lesson-detail.component.html',
  styles: ['::ng-deep .p-calendar .p-inputtext {flex: 0 0 auto;width: 100%;margin-top: -11px;    margin-left: -16px;margin-right: -16px;}']
})
export class LessonDetailComponent implements OnInit {

  @Input() formGroupName: string;
  basicLessonForm: FormGroup;

  academicLevels:DropDownModel[]=[];
  academicYears:DropDownModel[]=[];
  subjects:DropDownModel[]=[];
  classNames:DropDownModel[]=[];

  isDisable:boolean=false;


  constructor( private dropDownService:DropdownService,
    private lessonService:LessonService,
    private rootFormGroup: FormGroupDirective,
    private router: Router,
    private primengConfig: PrimeNGConfig,
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private spinner: NgxSpinnerService) {

      this.lessonService.onLessonDetailAssigned.subscribe(response=>{
          this.loadClasses();

      });

     }

  ngOnInit(): void {
    this.basicLessonForm = this.rootFormGroup.control.get(this.formGroupName) as FormGroup;
    this.spinner.show();
    this.loadMasterData();
  }

  loadMasterData()
  {
      this.lessonService.getLessonMasterData().subscribe(response=>{
          this.academicYears = response.academicYears;
          this.academicLevels= response.academicLevels;

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


