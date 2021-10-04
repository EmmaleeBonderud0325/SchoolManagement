import { MCQQuestionAnswerPaginatedItemsViewModel } from './../../models/mcq-question-answer/mcqquestionanswer.paginated.item';
import { environment } from 'src/environments/environment';
import { DropDownModel } from './../../models/common/drop-down.model';
import { ResponseModel } from 'src/app/models/common/response.model';
import { MCQQuestionAnswerModel } from './../../models/mcq-question-answer/mcq-question-answer.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class McqQuestionAnswerService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<MCQQuestionAnswerModel[]>{
      return this.httpClient.
      get<MCQQuestionAnswerModel[]>
      (environment.apiUrl + 'MCQQuestionAnswer/getAll');
  }
 
  saveMCQQuestionAnswer(vm: MCQQuestionAnswerModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>
      (environment.apiUrl + 'MCQQuestionAnswer', vm);
  }

  getAllQuestions():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>
      (environment.apiUrl + 'MCQQuestionAnswer/getAllQuestions');
  }

  getQuestionList(searchText: string, currentPage: number, pageSize: number, questionId:number,):Observable<MCQQuestionAnswerPaginatedItemsViewModel>{
    return this.httpClient.get<MCQQuestionAnswerPaginatedItemsViewModel>(environment.apiUrl + "MCQQuestionAnswer/getQuestionList",{
      params:new HttpParams()
        .set('searchText',searchText)
        .set('currentPage', currentPage.toString())
        .set('pageSize', pageSize.toString())
        .set('questionId', questionId.toString())
    });
  }
     
}
