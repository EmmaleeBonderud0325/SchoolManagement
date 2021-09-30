import { FormBuilder, FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { TopicContentModel } from './topic.content';
import { Injectable } from "@angular/core";
@Injectable()
export class LessonTopicModel
{
    id:number;
    lessonId:number;
    name:string;
    sequenceNo:number;
    learningExperince:string;
    topicContent:TopicContentModel[];

    static asFormGroup(item:LessonTopicModel,isDisable:boolean,fb:FormBuilder): FormGroup
    {
        const fg = new FormGroup({
            id: new FormControl(item.id),
            name: new FormControl(item.name,[Validators.required]),
            sequenceNo: new FormControl(item.sequenceNo),
            topicContent:fb.array([])
        });

        const cf = item.topicContent.map((value, index) => { return TopicContentModel.asFormGroup(value, isDisable) });
        const fArray = new FormArray(cf);
        fg.setControl('topicContent', fArray);

        if(isDisable)
        {
            fg.get("name").disable();
        }

        return fg;
    }

}