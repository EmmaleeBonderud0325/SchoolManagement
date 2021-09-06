import { Injectable } from '@angular/core';

export class LessonModel
{
    id:number;
    name:string;
    ownerId:number;
    description:string;
    version:number;
    learningOutcome:string;
    status:string;
    plannedDate:Date;
    completeDate:Date;
    createdOn:Date;
    isActive:boolean;
    createdById:number;
    updateOn:number;
    updatedById:number;
    introduction:string;
    topicId:number;
    content:string;
    SelectedOwnerId:number
    SelectedAcademicLevelId:number
    SelectedClassNameId:number
    SelectedAcademicYearId:number
    SelectedSubjectId:number
}