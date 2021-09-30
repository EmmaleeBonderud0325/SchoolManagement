import { LessonTopicModel } from './../../../models/lesson/lesson.topic.model';
import { LessonService } from './../../../services/lesson/lesson.service';
import { PrimeNGConfig } from 'primeng/api';
import { NgxSpinnerService } from 'ngx-spinner';
import { FormGroup, FormBuilder, FormControl, Validators, FormArray } from '@angular/forms';
import { LessonModel } from './../../../models/lesson/lesson.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-lesson-container',
  templateUrl: './lesson-container.component.html',
  styleUrls: ['./lesson-container.component.sass']
})
export class LessonContainerComponent implements OnInit {

  menuItems: LessonMenu[];
  selectedMenu:LessonMenu;
  lessonId:number=0;
  lesson:LessonModel = new LessonModel();
  lessonForm:FormGroup;

  isDisable:boolean=false;

  constructor( 
    public activateRoute: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private primengConfig: PrimeNGConfig,
    private lessonService:LessonService,
    private fb: FormBuilder) { }

  ngOnInit(): void {

    this.primengConfig.ripple = true;
    this.menuItems = [
      {name: 'Lesson Details', code: 'NY',id: 1},
      {name: 'Lesson Content', code: 'PRS',id: 5}
  ];

  this.selectedMenu=this.menuItems[0];

  this.activateRoute.params.subscribe(params => {
    this.lessonId = +params.id;
    this.spinner.show();
    //this.getLesson();

  });
  }


  createLessonForm():FormGroup {
    return new FormGroup({
   
        id: new FormControl(0),
        lessonDetail: this.fb.group({
        lessonId:new FormControl(0),
        name:new FormControl(""),
        lessonIntroduction: new FormControl(""),
        academicYearId: new FormControl(null,[Validators.required]),
        lessonStatus:new FormControl(null,[Validators.required]),
        assignedClasses:new FormControl([]),
      }),
     
      lessonTopics: this.fb.array([]),
      
    });
  }


  menuClicked(menu:LessonMenu)
  {
    this.selectedMenu=menu;
  }

  getLesson()
  {
    this.lessonService.getLessonById(this.lessonId)
      .subscribe(response=>{
        this.spinner.hide();
        this.lesson = response;
/*         this.lessonForm = new FormGroup({
   
          id: new FormControl(response.id),
          lessonDetail: this.fb.group({
            name:new FormControl(response.lessonDetail.name),
            lessonIntroduction: new FormControl(response.lessonDetail.lessonIntroduction),
            duration: new FormControl(response.lessonDetail.duration),
            competencyLevel: new FormControl(response.lessonDetail.competencyLevel,[Validators.required]),
            teachingProcess: new FormControl(response.lessonDetail.teachingProcess,[Validators.required]),
            academicYearId: new FormControl(response.lessonDetail.academicYearId,[Validators.required]),
            gradeId: new FormControl(response.lessonDetail.gradeId,[Validators.required]),
            subjectId: new FormControl(response.lessonDetail.subjectId,[Validators.required]),
            lessonStatus:new FormControl(response.lessonDetail.lessonStatus,[Validators.required]),
            teacherAids:new FormControl(response.lessonDetail.teacherAids),
            assignedClasses:new FormControl(response.lessonDetail.assignedClasses),
          }),
          lessonPrerequisites: this.fb.array([]),
          lessonOutcomes: this.fb.array([]),
          lessonTopics: this.fb.array([]),
          lessonUnitTests: this.fb.array([])
        }); */

       /* this.lessonForm.get("id").setValue(response.id);
        this.lessonForm.get("lessonDetail.lessonId").setValue(response.lessonDetail.lessonId);
        this.lessonForm.get("lessonDetail.name").setValue(response.lessonDetail.name);
        this.lessonForm.get("lessonDetail.lessonIntroduction").setValue(response.lessonDetail.lessonIntroduction);
        this.lessonForm.get("lessonDetail.academicYearId").setValue(response.lessonDetail.academicYearId);
        this.lessonForm.get("lessonDetail.academicYearId").disable();
        this.lessonForm.get("lessonDetail.gradeId").setValue(response.lessonDetail.gradeId);

        this.lessonForm.get("lessonDetail.subjectId").setValue(response.lessonDetail.subjectId);
        this.lessonForm.get("lessonDetail.lessonStatus").setValue(response.lessonDetail.lessonStatus);

        const lessonTopicsform = response.lessonTopics.map((value, index) => { return LessonTopicModel.asFormGroup(value, this.isDisable,this.fb) });
        const lessonTopicsformArray = new FormArray(lessonTopicsform);
        this.lessonForm.setControl('lessonTopics', lessonTopicsformArray);

       

        this.lessonService.onLessonValueAssigned.next(true);*/


      },error=>{
        this.spinner.hide();
      });
  }
  
  get lessonName()
  {
    return  this.lessonForm.get("lessonDetail.name").value;
  }

}
interface LessonMenu {
  name: string,
  code: string,
  id:number
}