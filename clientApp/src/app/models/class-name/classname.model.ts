import { Injectable } from '@angular/core';

@Injectable()
export class classnameModel{
    id:number;
    name:string;
    description:string;
    isActive:boolean;
    createdOn:Date;
    createdById:number;
    createdByName:string;
    updatedOn:Date;
    updatedById:number;
    updatedByName:string;
}