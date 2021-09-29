import { CheckBoxModel } from './../common/check-box-model';
import { Injectable } from '@angular/core';

@Injectable()
export class UserModel
{
    id:number;
    fullName:string;
    email:string;
    address:string;
    username:string;
    mobileNo:string;
    password:string;
    isActive:boolean;
    roles:number[];
    createdOn:Date;
    createdById:number; 
    createdByName:string; 
    updatedOn:Date;
    updatedByName:string;
    updatedById:number;
}