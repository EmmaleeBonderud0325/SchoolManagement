
import {​​​​​​​​ ResponseModel }​​​​​​​​ from'../../models/common/response.model';
import {​​​​​​​​ environment }​​​​​​​​ from'../../../environments/environment';
import { EssayQuestionAnswerModel } from '../../models/essay-answer/essay.answer.model';
import {​​​​​​​​ Observable }​​​​​​​​ from'rxjs';
import {​​​​​​​​ HttpClient }​​​​​​​​ from'@angular/common/http';
import {​​​​​​​​ Injectable }​​​​​​​​ from'@angular/core';
 
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
post<ResponseModel>(environment.apiUrl + 'essay-answer/saveEssayQuestionAnswer', essayanswer);
  }​​​​​​​​

}​​​​​​​​

