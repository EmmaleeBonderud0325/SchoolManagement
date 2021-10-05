
import {​​​​​​​​ ResponseModel }​​​​​​​​ from'../../models/common/response.model';
import {​​​​​​​​ environment }​​​​​​​​ from'../../../environments/environment';
import { EssayQuestionAnswerModel } from '../../models/essay-answer/essay.answer.model';
import {​​​​​​​​ Observable }​​​​​​​​ from'rxjs';
import {​​​​​​​​ HttpClient, HttpParams }​​​​​​​​ from'@angular/common/http';
import {​​​​​​​​ Injectable }​​​​​​​​ from'@angular/core';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { EssayAnswerPaginatedItemsViewModel } from 'src/app/models/essay-answer/essay.answer.paginated.items';
 
@Injectable({​​​​​​​​
providedIn:'root'
}​​​​​​​​)
 
export class EssayQuestionAnswerService {​​​​​​​​
 
constructor(private httpClient: HttpClient) {​​​​​​​​ }​​​​​​​​
 
getAll(): Observable <EssayQuestionAnswerModel[]>{​​​​​​​​
return this.httpClient.
get<EssayQuestionAnswerModel[]>(environment.apiUrl + 'EssayQuestionAnswer')
  }​​​​​​​​
 
saveEssayQuestionAnswer(essayanswer: EssayQuestionAnswerModel): Observable<ResponseModel> {​​​​​​​​
return this.httpClient.
post<ResponseModel>(environment.apiUrl + 'EssayQuestionAnswer', essayanswer);
  }​​​​​​​​

delete(id: number): Observable<ResponseModel> {
   return this.httpClient. 
   delete<ResponseModel>(environment.apiUrl + 'EssayQuestionAnswer/' + id);
   }

getAllQuestions():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'EssayQuestionAnswer/getAllQuestions');
  }

  getQuestionList(searchText: string, currentPage: number, pageSize: number, questionId:number,):Observable<EssayAnswerPaginatedItemsViewModel>{
    return this.httpClient.get<EssayAnswerPaginatedItemsViewModel>(environment.apiUrl + "EssayQuestionAnswer/getQuestionList",{
      params:new HttpParams()
        .set('searchText',searchText)
        .set('currentPage', currentPage.toString())
        .set('pageSize', pageSize.toString())
        .set('questionId', questionId.toString())

    });

}​​​​​​​​

}