import { Injectable } from '@angular/core';

@Injectable()
export class AcademicLevelModel{
    id:number;
    name:string;
    levelHeadId:number;
    levelHeadName:string;
    isActive:boolean;
    createdOn:Date;
    createdById:number;
    createdByName:string;
    updatedOn:Date;
    updatedById:number;
    updatedByName:string;
}