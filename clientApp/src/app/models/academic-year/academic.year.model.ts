import { Injectable } from '@angular/core';

@Injectable()
export class AcademicYearModel{
    id:number;
    isActive:boolean;
    createdOn:Date;
    createdById:number;
    createdByName:string;
    updatedOn:Date;
    updatedById:number;
    updatedByName:string;
       
}