import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {​​​​​​​​ ResponseModel }​​​​​​​​ from'../../models/common/response.model';
import {​​​​​​​​ environment }​​​​​​​​ from'../../../environments/environment';
import { EssayStudentAnswerModel } from '../../models/essay-student-answer/essay.student.answer.model';
import { Observable } from 'rxjs';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { EssayStudentAnswerPaginatedItemsViewModel } from 'src/app/models/essay-student-answer/essay.student.answer.paginated.items';

@Injectable({
  providedIn: 'root'
})
export class EssayStudentAnswerService {

  constructor(private httpClient: HttpClient) {​​​​​​​​ }​​​​​​​​
   
  getAll(): Observable <EssayStudentAnswerModel[]>{​​​​​​​​
    return this.httpClient.
    get<EssayStudentAnswerModel[]>(environment.apiUrl + 'EssayStudentAnswer')
    }​​​​​​​​
   
  saveEssayStudentAnswer(essaystudentanswer: EssayStudentAnswerModel): Observable<ResponseModel> {​​​​​​​​
    return this.httpClient.
    post<ResponseModel>(environment.apiUrl + 'EssayStudentAnswer', essaystudentanswer);
    }​​​​​​​​
  
  delete(QuestionId: number): Observable<ResponseModel> { 
    return this.httpClient.
    delete<ResponseModel>(environment.apiUrl + 'EssayStudentAnswer' + QuestionId);
      }

  getAllQuestions():Observable<DropDownModel[]>{
      return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'EssayStudentAnswer/getAllQuestions');
      }

  getAllStudents():Observable<DropDownModel[]>{
      return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'EssayStudentAnswer/getAllStudents');
      }
   
  getAllEssayQuestionAnswers():Observable<DropDownModel[]>{
        return this.httpClient.
        get<DropDownModel[]>(environment.apiUrl + 'EssayStudentAnswer/getAllEssayQuestionAnswers');
        }



        getStudentEssayList(searchText: string, currentPage: number, pageSize: number, questionId:number,studentId:number):Observable<EssayStudentAnswerPaginatedItemsViewModel>{
          return this.httpClient.get<EssayStudentAnswerPaginatedItemsViewModel>(environment.apiUrl + "EssayQuestionAnswer/getStudentEssayList",{
            params:new HttpParams()
              .set('searchText',searchText)
              .set('currentPage', currentPage.toString())
              .set('pageSize', pageSize.toString())
              .set('questionId', questionId.toString())
              .set('studentId', studentId.toString())
      
          });
        }
         

  }​​​​​​​​

