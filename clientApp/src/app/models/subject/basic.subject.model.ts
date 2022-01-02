import { Injectable } from '@angular/core';

@Injectable()
export class BasicSubjectModel
{
    id:number; 
    name:string;
    subjectCode:string;
    subjectCategory:number;
    subjectCategoryName:string;
    subjectStreamId:number;
    parentBasketSubjectId:number;
    parentBasketSubjectName:string;
    subjectType:number;
    subjectStreamName:string;
    createdByName:string;
    createdOn:Date;
    updatedOn:Date;
    updatedByName:string; 
}