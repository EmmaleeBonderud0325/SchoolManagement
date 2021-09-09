import { Injectable } from '@angular/core';

@Injectable()
export class HeadOfDepartmentModel{
    id:number;
    subjectId:number;
    academicLevelId:number;
    academicYearId:number;
    teacherId:number;
    isActive:boolean;
    createdOn:Date;
    createdById:number;
    updatedOn:Date;
    updatedById:number;
}
