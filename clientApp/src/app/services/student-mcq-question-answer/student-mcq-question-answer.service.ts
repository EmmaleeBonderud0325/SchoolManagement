import { DropDownModel } from './../../models/common/drop-down.model';
import { ResponseModel } from './../../models/common/response.model';
import { environment } from './../../../environments/environment';
import { StudentMcqQuestionAnswerModel } from './../../models/student-mcq-question-answer/student-mcq-question-answer';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StudentMcqQuestionAnswerService {
  constructor( private httpClient: HttpClient ) { }


  getAll(): Observable<StudentMcqQuestionAnswerModel[]>{
    return this.httpClient.
      get<StudentMcqQuestionAnswerModel[]>
      (environment.apiUrl + 'StudentMCQQuestion/getAll');
  }
 
  saveStudentMcqQuestionAnswer(vm: StudentMcqQuestionAnswerModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>
      (environment.apiUrl + 'StudentMCQQuestion', vm);
  }
  
  getAllQuestions():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>
      (environment.apiUrl + 'StudentMCQQuestion/getAllQuestions');
  }

  getAllStudentNames():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>
      (environment.apiUrl + 'StudentMCQQuestion/getAllStudentNames');
  }
  
}
