import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { ResponseModel } from 'src/app/models/common/response.model';
import { environment } from 'src/environments/environment';
import { HeadOfDepartmentModel } from './../../models/head-of-department/head.of.department.model';
import { HeadOfDepartmentPaginatedItemViewModel } from "src/app/models/head-of-department/head.of.department.paginated.item.model";

@Injectable({
  providedIn: 'root'
})
export class HeadOfDepartmentService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<HeadOfDepartmentModel[]> {
    return this.httpClient.
      get<HeadOfDepartmentModel[]>
        (environment.apiUrl + 'HeadOfDepartment');
  }

  saveHeadOfDepartment(vm: HeadOfDepartmentModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>
        (environment.apiUrl + 'HeadOfDepartment/saveHeadOfDepartment', vm);
  }

  delete(id: number): Observable<ResponseModel> {
    return this.httpClient.
      delete<ResponseModel>
        (environment.apiUrl + 'HeadOfDepartment/' + id);
  }
  
  getAllAcademicYears():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>
        (environment.apiUrl + 'HeadOfDepartment/getAllAcademicYears');
  }

  getAllAcademicLevels():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>
        (environment.apiUrl + 'HeadOfDepartment/getAllAcademicLevels');
  }

  getAllTeachers():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>
        (environment.apiUrl + 'HeadOfDepartment/getAllTeachers');
  }

  getAllSubjects():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>
        (environment.apiUrl + 'HeadOfDepartment/getAllSubjects');
  }

  getHeadOfDepartmentList(searchText: string, currentPage: number, pageSize: number):Observable<HeadOfDepartmentPaginatedItemViewModel>{
    return this.httpClient.get<HeadOfDepartmentPaginatedItemViewModel>(environment.apiUrl + "HeadOfDepartment/getHeadOfDepartmentList",{
      params:new HttpParams()
        .set('searchText',searchText)
        .set('currentPage', currentPage.toString())
        .set('pageSize', pageSize.toString())
      });
      
      }

      downloadHeadOdDepartmentListReport(): Observable<any> {
        return this.httpClient.get<any>
        (environment.apiUrl +'HeadOfDepartment/downloadheadOfDepartmentList');
  }
}
