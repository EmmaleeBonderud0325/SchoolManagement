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
            contentType: new FormControl(item.contentType,[Validators.required]),
            content: new FormControl(item.content,[Validators.required]),
        });

        if(isDisable)
        {
            formGroup.get("name").disable();
            formGroup.get("contentType").disable();
            formGroup.get("content").disable();
        }

        return formGroup;
    }
}