import { DropDownModel } from './../../models/common/drop-down.model';
import { ResponseModel } from 'src/app/models/common/response.model';
import { environment } from './../../../environments/environment.prod';
import { MCQQuestionAnswerModel } from './../../models/mcq-question-answer/mcq-question-answer.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class McqQuestionAnswerService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<MCQQuestionAnswerModel[]>{
    return this.httpClient.
      get<MCQQuestionAnswerModel[]>(environment.apiUrl + 'MCQQuestionAnswer')
  }
 
  saveMcqQuestionAnswer(mcqquestionanswer: MCQQuestionAnswerModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'MCQQuestionAnswer/', mcqquestionanswer);
  }

  GetAllQuestion():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'MCQQuestionAnswer/getAllQuestion');
  }
  
}
