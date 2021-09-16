import { Injectable } from '@angular/core';

@Injectable()
export class BasicUserModel
{
    id:number; 
    fullName:string;
    email:string;
    mobileNo:string;
    username:string;
    address:string;
    createdOn:string;
    createdByName:string;
    updatedOn:string;
    updatedByName:string; 
}