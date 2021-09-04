import { Injectable } from '@angular/core';

@Injectable()
export class StudentModel {
    id:number;
    admissionNo:number;
    emegencyContactNo1:string;
    emegencyContactNo2:string;
    gender:number;
    dateOfBirth:Date;
    isActive:boolean;
}