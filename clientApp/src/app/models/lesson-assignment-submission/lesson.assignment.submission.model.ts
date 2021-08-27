import { Injectable } from '@angular/core';

@Injectable()
export class LessonAssignmentSubmissionModel{
    id:number;
    lessonAssignmentId:number;
    studentId :number ;
    submissionPath :string;
    submissionDate :Date;
    marks: number;
    teacherComments : string;
    
}
