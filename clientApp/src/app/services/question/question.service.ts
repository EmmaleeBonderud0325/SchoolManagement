import { DropDownModel } from 'src/app/models/common/drop-down.model';
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
 
  saveQuestion(vm: questionModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'Question', vm);
  }
  
  delete(id: number): Observable <ResponseModel> { 
    return this.httpClient. 
      delete<ResponseModel>(environment.apiUrl + 'Question/' + id); 
  }

  getAllLessonName():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'Question/getAllLessonName');
  }

  getAllTopic():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'Question/getAllTopic');
  }

}


