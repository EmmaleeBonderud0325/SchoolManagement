import { Injectable } from '@angular/core';

@Injectable()
export class StudentModel {
    id:number;
    admissionNo:number;
    emegencyContactNo:string;
    gender:number;
    dateOfBirth:Date;
    isActive:boolean;
    genderName:string;

    fullName:string;
    email:string;
    password:string;
    address:string;
    mobileNo:string;
    username:string;
}