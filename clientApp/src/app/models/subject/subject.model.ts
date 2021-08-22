import { Injectable } from '@angular/core';

@Injectable()
export class SubjectModel{
    id:number;
    name:string;
    subjectCode:string;
    subjectCategory:string;
    isParentBasketSubject:boolean;
    isBuscketSubject:boolean;
    parentBasketSubjectId:number;
    subjectStreamId:number;
    subjectStreamName:string;
    isActive:boolean;
}