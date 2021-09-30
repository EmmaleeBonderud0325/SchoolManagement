import { LessonService } from './../../../services/lesson/lesson.service';
import { PrimeNGConfig } from 'primeng/api';
import { NgxSpinnerService } from 'ngx-spinner';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
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
        teacherAids:new FormControl([]),
        assignedClasses:new FormControl([]),
      }),
     
      lessonTopics: this.fb.array([]),
      
    });
  }

}
interface LessonMenu {
  name: string,
  code: string,
  id:number
}