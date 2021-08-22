import { questionModel } from './../../models/question/question.model';
import { ResponseModel } from '../../models/common/response.model';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
 
@Injectable({
  providedIn: 'root'
})
 
export class QuestionService {
 
  constructor(private httpClient: HttpClient) { }
 
  getAll(): Observable<questionModel[]>{
    return this.httpClient.
      get<questionModel[]>(environment.apiUrl + 'Question')
  }
 
  saveQuestion(question: questionModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'question/saveQuestion', question);
  }
  
}


