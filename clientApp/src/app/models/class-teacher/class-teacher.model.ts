import { Injectable } from '@angular/core';

@Injectable()
export class classteacherModel{
    classNameId:number;
    academicLevelId:number;
    academicYearId:number;
    teacherId:number;
    isPrimary:boolean;
    isActive:boolean;
    createdOn:Date;
    createdById:number;
    createdByName:string;
    updatedOn:Date;
    updatedById:number;
    updatedByName:string;
}