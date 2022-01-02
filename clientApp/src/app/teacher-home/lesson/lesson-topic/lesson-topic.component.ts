import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, MessageService } from 'primeng/api';
import { EMPTY, Observable } from 'rxjs';
import { Upload } from 'src/app/models/common/upload';
import { LessonService } from 'src/app/services/lesson/lesson.service';

@Component({
  selector: 'lesson-topic',
  templateUrl: './lesson-topic.component.html',
  styleUrls: ['./lesson-topic.component.sass'],
})
export class LessonTopicComponent implements OnInit {

  form!: FormGroup;
  displayContentTypeSelector:boolean=false;
  selectedLecture:FormGroup;


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

  showContentTypeSelector(item:FormGroup)
  {
    this.selectedLecture = item;
    this.displayContentTypeSelector = true;
  }

  setContentType(contentType:number)
  {
    this.displayContentTypeSelector = false;
    this.selectedLecture.get("contentType").setValue(contentType);
  }

  @Input() accept = 'video/*';
  fileName: string = '';
  upload$: Observable<Upload> = EMPTY;
  precentage:any;
  onFileChange(event: any,item:FormGroup)
  {
    let fi = event.srcElement;
    const formData = new FormData();
    formData.set("id",item.get("id").value.toString());
    formData.set("topicId",item.get("topicId").value.toString());
    formData.set("contentType",item.get("contentType").value.toString());

    console.log(formData);
    
    
    if(fi.files.length>0)
    {
        //this._fuseProgressBarService.show();
        for (let index = 0; index < fi.files.length; index++) {
          
          formData.append('file', fi.files[index], fi.files[index].name);
        }
        this.lessonService.uploadLessonFile(formData).subscribe(res=>
          {
            this.precentage =res;
            console.log(res);
            
            if(res.state=="DONE")
            {
              //item.isUploading=false;
              //this._fuseProgressBarService.hide();
              //this.loadList();
            }
            //progress
          },error=>{
            //this._fuseProgressBarService.hide();
            //item.isUploading=false;


          });
/*         this._quotationService.uploadQuotationFiles(formData)
          .subscribe(response=>{
 
          },error=>{
            console.log("Error occured");
            
          }); */
    } 
  }
}
