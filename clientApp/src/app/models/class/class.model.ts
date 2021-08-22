import { Injectable } from '@angular/core';

@Injectable()
export class ClassModel{
    classNameId:number;
    academicLevelId:number;
    academicYearId:number;
    name:string;
    classCategory:string;
    languageStream:string;
    createdOn:Date;
    createdById:number;
    createdByName:string;
    updatedOn:Date;
    updatedById:number;
    updatedByName:string;
}