import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {​​​​​​​​ ResponseModel }​​​​​​​​ from'../../models/common/response.model';
import {​​​​​​​​ environment }​​​​​​​​ from'../../../environments/environment';
import { EssayStudentAnswerModel } from '../../models/essay-student-answer/essay.student.answer.model';
import { Observable } from 'rxjs';

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
  post<ResponseModel>(environment.apiUrl + 'essay-student-answer/saveEssayStudentAnswer', essaystudentanswer);
    }​​​​​​​​
  
    delete(QuestionId: number): Observable<ResponseModel> { 
      return this.httpClient.
       delete<ResponseModel>(environment.apiUrl + 'essay-student-answer' + QuestionId);
      }
  }​​​​​​​​
