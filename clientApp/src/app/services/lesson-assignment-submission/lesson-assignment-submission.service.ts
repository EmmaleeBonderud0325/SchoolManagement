import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseModel } from 'src/app/models/common/response.model';
import {​​​​​​​​ environment }​​​​​​​​ from'../../../environments/environment';
import { LessonAssignmentSubmissionModel } from '../../models/lesson-assignment-submission/lesson.assignment.submission.model';

@Injectable({
  providedIn: 'root'
})
export class LessonAssignmentSubmissionService {

  constructor(private httpClient: HttpClient) {​​​​​​​​ }​​​​​​​​
   
  getAll(): Observable <LessonAssignmentSubmissionModel[]>{​​​​​​​​
  return this.httpClient.
  get<LessonAssignmentSubmissionModel[]>(environment.apiUrl + 'LessonAssignmentSubmission')
    }​​​​​​​​
   
  saveLessonAssignmentSubmission(lessonassignmentsubmission: LessonAssignmentSubmissionModel): Observable<ResponseModel> {​​​​​​​​
  return this.httpClient.
  post<ResponseModel>(environment.apiUrl + 'lessopn-assignment-submission/saveLessonAssignmentSubmission', lessonassignmentsubmission);
    }​​​​​​​​
  
}
