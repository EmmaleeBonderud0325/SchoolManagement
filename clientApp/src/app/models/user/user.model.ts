import { RoleModel } from './role.model';
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
    roles:RoleModel[];
}