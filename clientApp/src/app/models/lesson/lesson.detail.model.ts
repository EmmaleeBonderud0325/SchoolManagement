import { Injectable } from "@angular/core";
@Injectable()
export class LessonDetailModel
{
    lessonId:number;
    name:string;
    description:string;
    
    ownerId:number;
    academicLevelId:number;
    classNameid:number;
    academicYearId:number;
    subjectId:number;

    versionNo:number;
    learningOutCome:string;
    plannedDate:Date;
}