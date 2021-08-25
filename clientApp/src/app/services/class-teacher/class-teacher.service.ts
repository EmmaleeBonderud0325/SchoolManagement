import { DropDownModel } from './../../models/common/drop-down.model';
import { ResponseModel } from '../../models/common/response.model';
import { environment } from '../../../environments/environment';
import { classteacherModel } from '../../models/class-teacher/class-teacher.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class ClassTeacherService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<classteacherModel[]>{
    return this.httpClient.
      get<classteacherModel[]>(environment.apiUrl + 'ClassTeacher')
  }

  save(vm: classteacherModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'ClassTeacher', vm);
  }

  delete(classNameId: number): Observable<ResponseModel> {
    return this.httpClient.
      delete<ResponseModel>(environment.apiUrl + 'ClassTeacher/' + classNameId);
  }

  getAllTeachers():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'ClassTeacher/getAllTeachers');
  }
}