import { CheckBoxModel } from './../common/check-box-model';
import { Injectable } from '@angular/core';

@Injectable()
export class SubjectModel{
    id:number;
    name:string;
    subjectCode:string;
    subjectCategory:number;
    categorysId:number;
    subjectCategoryName:string;
    isParentBasketSubject:boolean;
    isBuscketSubject:boolean;
    parentBasketSubjectId:number;
    parentBasketSubjectName:string;
    subjectStreamId:number;
    subjectStreamName:string;
    isActive:boolean;
    createdOn:Date;
    updatedOn:Date;
    subjectAcademicLevels:CheckBoxModel[];
}