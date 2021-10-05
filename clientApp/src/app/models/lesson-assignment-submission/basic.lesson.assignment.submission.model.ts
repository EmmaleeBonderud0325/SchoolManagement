import { Injectable } from '@angular/core';

@Injectable()
export class BasicLessonAssignmentSubmissionModel{
    id:number;
    lessonAssignmentId:number;
    lessonAssignmentNamw:number;
    studentId :number ;
    studentName :number ;
    submissionPath :string;
    submissionDate :Date;
    marks: number;
    teacherComments : string;
    
}