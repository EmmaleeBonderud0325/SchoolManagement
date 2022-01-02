import { Injectable } from '@angular/core';

@Injectable()
export class ResetPasswordModel
{
    schoolDomain:string
    email:string
    newPassword:string 
    confirmPassword:string
}