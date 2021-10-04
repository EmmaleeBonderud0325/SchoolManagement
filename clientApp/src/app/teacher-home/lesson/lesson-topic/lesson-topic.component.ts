import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, MessageService } from 'primeng/api';
import { LessonService } from 'src/app/services/lesson/lesson.service';

@Component({
  selector: 'lesson-topic',
  templateUrl: './lesson-topic.component.html',
  styleUrls: ['./lesson-topic.component.sass'],
})
export class LessonTopicComponent implements OnInit {

  form!: FormGroup;
  displayContentTypeSelector:boolean=false;


  constructor(private rootFormGroup: FormGroupDirective,
    private lessonService:LessonService, 
    private spinner:NgxSpinnerService,  
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.rootFormGroup.control;
  }

  trackByFn(index, row) {
    return index;
  } 

  addNewTopic()
  {
    console.log(this.form);
    
    const fg = new FormGroup({
      id: new FormControl(0),
      lessonId:new FormControl(this.form.get('id').value),
      name: new FormControl(null,[Validators.required]),
      sequenceNo: new FormControl(0),
      topicContents:this.fb.array([]),
      editable:new FormControl(true)
  });

  this.topics().push(fg);
  }

  onDeleteLessonTopic(rowIndex:number): void {  
    this.topics().removeAt(rowIndex);  
 }  

 topics(): FormArray {  
    return this.form.get('topics') as FormArray;  
 }
 
 topicContents(topicIndex:number):FormArray{

  return this.topics().at(topicIndex).get("topicContents") as FormArray;
  
  if(this.topics().at(topicIndex).get("topicContents").value.length>0)
  {
    return this.topics().at(topicIndex).get("topicContents") as FormArray;
  }
  
   return this.fb.array([]);
 }

 editLessonTopic(item:FormGroup)
 {
  item.get('editable').setValue(true);
 }

 saveLessonTopicHeader(item:FormGroup)
 {
    this.spinner.show();
    this.lessonService.saveTopic(item.getRawValue())
      .subscribe(response=>{
        this.spinner.hide();
        item.get('id').setValue(response.id);
        item.get('editable').setValue(false);
      },error=>{
        this.spinner.hide();
      });

 }



 lessonLectureLength(topicIndex:number):number
 {
    return this.topics().at(topicIndex).get("topicContents").value.length;
 }
   
addTopicContent(topicIndex:number) {

    const formGroup = new FormGroup({
      id: new FormControl(0),
      topicId: new FormControl(this.topics().at(topicIndex).get('id').value),
      name: new FormControl('',[Validators.required]),
      introduction:new FormControl('',[Validators.required]),
      contentType: new FormControl(1),
      content: new FormControl(''),
      editable:new FormControl(true),
  });

      this.topicContents(topicIndex).push(formGroup);
}
   
removeTopicContent(topicIndex:number,topicContentIndex:number) {
      this.topicContents(topicIndex).removeAt(topicContentIndex);
}

  editLecture(item:FormGroup)
  {
    item.get('editable').setValue(true);
  }

  saveLecture(item:FormGroup)
  {
    this.spinner.show();
    this.lessonService.saveTopicContent(item.getRawValue())
      .subscribe(response=>{
        this.spinner.hide();
        item.get('id').setValue(response.id);
        item.get('editable').setValue(false);
      },error=>{
        this.spinner.hide();
      });
  }

  showContentTypeSelector()
  {
    this.displayContentTypeSelector = true;
  }
}
