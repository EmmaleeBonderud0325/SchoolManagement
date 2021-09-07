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
  
  getAll(): Observable <StudentMcqQuestionAnswerModel[]>{
    return this.httpClient.
      get<StudentMcqQuestionAnswerModel[]>(environment.apiUrl + 'StudentMcqQuestionAnswer')
  }

  saveStudentMcqQuestionAnswer(studentmcqquestionanswer: StudentMcqQuestionAnswerModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'StudentMcqQuestionAnswer/saveStudentMcqQuestionAnswer', studentmcqquestionanswer);
  }

  GetAllQuestion():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'StudentMcqQuestionAnswer/GetAllQuestion');
  }

  GetAllStudentName():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'StudentMcqQuestionAnswer/GetAllStudentName');
  }

}
