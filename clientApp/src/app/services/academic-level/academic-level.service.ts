import { DropDownModel } from './../../models/common/drop-down.model';
import { ResponseModel } from './../../models/common/response.model';
import { environment } from './../../../environments/environment';
import { Observable } from 'rxjs';
import { AcademicLevelModel } from './../../models/academic-level/acdemic.level.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AcademicLevelService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<AcademicLevelModel[]> {
    return this.httpClient.
      get<AcademicLevelModel[]>(environment.apiUrl + 'AcademicLevel');
  }

  saveAcademicLevel(vm: AcademicLevelModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'AcademicLevel', vm);
  }

  delete(id: number): Observable<ResponseModel> {
    return this.httpClient.
      delete<ResponseModel>(environment.apiUrl + 'AcademicLevel/' + id);
  }
  
  getAllLevelHeads():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'AcademicLevel/getAllLevelHeads');
  }
}
