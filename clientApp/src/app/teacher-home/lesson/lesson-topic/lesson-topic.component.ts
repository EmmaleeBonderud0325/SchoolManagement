import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, FormGroupDirective, Validators } from '@angular/forms';

@Component({
  selector: 'lesson-topic',
  templateUrl: './lesson-topic.component.html',
  styleUrls: ['./lesson-topic.component.sass']
})
export class LessonTopicComponent implements OnInit {

  form!: FormGroup;

  constructor(private rootFormGroup: FormGroupDirective,    
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
      name: new FormControl(null,[Validators.required]),
      sequenceNo: new FormControl(0),
      topicContents:this.fb.array([])
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

 lessonLectureLength(topicIndex:number):number
 {
    return this.topics().at(topicIndex).get("topicContents").value.length;
 }


   
    addTopicContent(topicIndex:number) {

    const formGroup = new FormGroup({
      id: new FormControl(0),
      topicId: new FormControl(0),
      name: new FormControl('',[Validators.required]),
      introduction:new FormControl('',[Validators.required]),
      contentType: new FormControl(1),
      content: new FormControl(''),
  });

      this.topicContents(topicIndex).push(formGroup);
    }
   
    removeTopicContent(topicIndex:number,topicContentIndex:number) {
      this.topicContents(topicIndex).removeAt(topicContentIndex);
    }

}
