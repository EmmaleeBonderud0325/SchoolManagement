import { Injectable } from '@angular/core';

@Injectable()
export class LessonAssignmentModel{
    id:number;
    lessonId :number ;
    lessonName :string ;
    name :string;
    description:string;
    startDate:Date;
    dueDate:Date;
    isActive :boolean;
    createdOn :Date;
    createdById: number;
    createdByName: string;
    updatedOn : Date;
    updatedById :number;
    updatedByName :string;
}

       