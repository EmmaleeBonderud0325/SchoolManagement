import { ResponseModel } from 'src/app/models/common/response.model';
import { environment } from './../../../environments/environment.prod';
import { McqQuestionAnswerModel } from './../../models/mcq-question-answer/mcq-question-answer.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class McqQuestionAnswerService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<McqQuestionAnswerModel[]>{
    return this.httpClient.
      get<McqQuestionAnswerModel[]>(environment.apiUrl + 'McqQuestionAnswer')
  }
 
  saveMcqQuestionAnswer(mcqquestionanswer: McqQuestionAnswerModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'mcqquestionanswer/saveMcqQuestionAnswer', mcqquestionanswer);
  }

  delete(classNameId: number): Observable <ResponseModel> { 
    return this.httpClient. 
      delete<ResponseModel>(environment.apiUrl + 'question/' + classNameId); 
  }
  
}
