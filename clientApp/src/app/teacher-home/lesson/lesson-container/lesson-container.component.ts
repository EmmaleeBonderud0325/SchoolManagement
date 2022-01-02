import { LessonDetailModel } from './../../../models/lesson/lesson.detail.model';
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
  styleUrls: ['./lesson-container.component.scss']
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

    this.lessonForm = this.createLessonForm();
    this.primengConfig.ripple = true;
    this.menuItems = [
      {name: 'Lesson Details',id: 1},
      {name: 'Lesson Content',id: 2}
  ];

  this.selectedMenu=this.menuItems[0];

  this.activateRoute.params.subscribe(params => {
    this.lessonId = +params.id;
    this.getLesson();
  });

  }




  createLessonForm():FormGroup {
    return new FormGroup({
   
        id: new FormControl(0),
        lessonDetail: this.fb.group({
          lessonId: new FormControl(0,[Validators.required]),
          name:new FormControl("",[Validators.required]),
          description:new FormControl("",[Validators.required]),
          ownerId:new FormControl(0),
          academicYearId: new FormControl(null,[Validators.required]),
          academicLevelId: new FormControl(null,[Validators.required]),
          classNameId:new FormControl(null,[Validators.required]),
          subjectId:new FormControl(null,[Validators.required]),
          learningOutCome:new FormControl(''),
          plannedDate:new FormControl(null,[Validators.required]),
      }),
     
      topics: this.fb.array([]),
      
    });
  }


  menuClicked(menu:LessonMenu)
  {
    console.log(menu);
    
    this.selectedMenu=menu;
  }

  getLesson()
  {
    this.lessonService.getLessonById(this.lessonId)
      .subscribe(response=>{
        this.spinner.hide();
        this.lesson = response;

        console.log(response.lessonDetail.lessonId);
        this.lessonForm.get("id").setValue(response.id);
        this.lessonForm.get("lessonDetail.lessonId").setValue(response.lessonDetail.lessonId);
        this.lessonForm.get("lessonDetail.name").setValue(response.lessonDetail.name);
        this.lessonForm.get("lessonDetail.description").setValue(response.lessonDetail.description);
        this.lessonForm.get("lessonDetail.academicYearId").setValue(response.lessonDetail.academicYearId);
        this.lessonForm.get("lessonDetail.academicYearId").disable();
        this.lessonForm.get("lessonDetail.academicLevelId").setValue(response.lessonDetail.academicLevelId);
        this.lessonForm.get("lessonDetail.subjectId").setValue(response.lessonDetail.subjectId);
        this.lessonForm.get("lessonDetail.learningOutCome").setValue(response.lessonDetail.learningOutCome);
        this.lessonForm.get("lessonDetail.plannedDate").setValue(response.lessonDetail.plannedDate);

        const lessonTopicsform = response.topics.map((value, index) => { return LessonTopicModel.asFormGroup(value, this.isDisable,this.fb) });
        const lessonTopicsformArray = new FormArray(lessonTopicsform);
        this.lessonForm.setControl('topics', lessonTopicsformArray);

  
        


      
      this.lessonService.onLessonDetailAssigned.next(true);


      },error=>{
        this.spinner.hide();
      });
  }
  
  get lessonName()
  {
    return  this.lessonForm.get("lessonDetail.name").value;
  }

  get id()
  {
    return  this.lessonForm.get("lessonDetail.lessonId").value;
  }

  
    
    

}
interface LessonMenu {
  name: string,
  id:number
}