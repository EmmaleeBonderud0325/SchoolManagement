import { Injectable } from '@angular/core';

@Injectable()
export class HeadOfDepartmentModel{
    id:number;
    subjectId:number;
    subjectName:string;
    academicLevelId:number;
    academicLevelName:string;
    academicYearId:number;    
    teacherId:number;
    teacherName:string;
    isActive:boolean;
    createOn:Date;
    createdById:number;
    createdByName:string;
    updateOn:Date;
    updatedById:number;
    updatedByName:number;
}
