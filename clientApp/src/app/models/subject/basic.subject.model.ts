import { Injectable } from '@angular/core';

@Injectable()
export class BasicSubjectModel
{
    id:number; 
    name:string;
    subjectCode:string;
    subjectCategoryName:string;
    parentBasketSubjectName:string;
    subjectStreamName:string;
    createdByName:string;
    createdOn:Date;
    updatedOn:Date;
    updatedByName:string; 
}