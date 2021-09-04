import { ResponseModel } from 'src/app/models/common/response.model';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { McqQuestionStudentAnswerModel } from './../../models/mcq-question-student-answer/mcq-question-student-answer.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class McqQuestionStudentAnswerService {
  
  constructor( private httpClient: HttpClient ) { }

 
  getAll(): Observable<McqQuestionStudentAnswerModel[]>{
    return this.httpClient.
      get<McqQuestionStudentAnswerModel[]>(environment.apiUrl + 'McqQuestionStudentAnswer')
  }
 
  saveMcqStudentAnswer(mcqquestionstudentanswer: McqQuestionStudentAnswerModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'mcqquestionstudentanswer/saveMcqStudentAnswer', mcqquestionstudentanswer);
  }
}
