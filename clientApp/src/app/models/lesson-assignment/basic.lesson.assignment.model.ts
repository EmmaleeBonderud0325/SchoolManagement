  import { Injectable } from '@angular/core';

@Injectable()
export class BasicLessonAssignmentModel{
    id:number;
    lessonId :number ;
    lessonName :string ;
    name :string;
    description :string;
    startDate: Date;
    duetDate :Date;
    isActive :boolean;
    createdOn :Date;
    createdByName :string;
    updatedOn :Date;
    updatedByName :string;
    
} 

     