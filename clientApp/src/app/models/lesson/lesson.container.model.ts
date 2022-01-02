import { LessonDetailModel } from './lesson.detail.model';
import { Injectable } from "@angular/core";
@Injectable()
export class LessonContainerModel
{
    id:number;
    lessonDetails:LessonDetailModel;
}