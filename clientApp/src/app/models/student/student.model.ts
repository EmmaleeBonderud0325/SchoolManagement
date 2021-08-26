import { Injectable } from '@angular/core';

@Injectable()
export class StudentModel {
    studentId:number;
    admissionNumber:number;
    emergencyContact1:string;
    emergencyContact2:string;
    gender:number;
    dateOfBirth:Date;
    isActive:boolean;
    //fullName:string;
    //email:string;
    //password:string;
    //address:string;
}