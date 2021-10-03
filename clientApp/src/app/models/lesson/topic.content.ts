import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Injectable } from "@angular/core";
@Injectable()
export class TopicContentModel
{
    id:number;
    topicId:number;
    name:string;
    introduction:string;
    contentType:string;
    content:string;

    static asFormGroup(item:TopicContentModel,isDisable:boolean): FormGroup
    {
        const formGroup = new FormGroup({
            id: new FormControl(item.id),
            topicId: new FormControl(item.topicId),
            name: new FormControl(item.name,[Validators.required]),
            introduction:new FormControl(item.introduction,[Validators.required]),
            contentType: new FormControl(item.contentType),
            content: new FormControl(item.content),
        });

        if(isDisable)
        {
            formGroup.get("name").disable();
            formGroup.get("contentType").disable();
            formGroup.get("introduction").disable();
            formGroup.get("content").disable();
        }

        return formGroup;
    }
}