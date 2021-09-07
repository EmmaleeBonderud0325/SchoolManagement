import { ResponseModel } from 'src/app/models/common/response.model';
import { environment } from './../../../environments/environment.prod';
import { mcqquestionanswerModel } from './../../models/mcq-question-answer/mcq-question-answer.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class McqQuestionAnswerService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<mcqquestionanswerModel[]>{
    return this.httpClient.
      get<mcqquestionanswerModel[]>(environment.apiUrl + 'McqQuestionAnswer')
  }
 
  saveMcqQuestionAnswer(mcqquestionanswer: mcqquestionanswerModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'McqQuestionAnswer/', mcqquestionanswer);
  }

  delete(classNameId: number): Observable <ResponseModel> { 
    return this.httpClient. 
      delete<ResponseModel>(environment.apiUrl + 'McqQuestionAnswer/' + classNameId); 
  }
  
}
