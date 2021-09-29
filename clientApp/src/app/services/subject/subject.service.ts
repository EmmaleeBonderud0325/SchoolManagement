import { DropDownModel } from './../../models/common/drop-down.model';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SubjectModel } from './../../models/subject/subject.model';
import { environment } from 'src/environments/environment';
import { ResponseModel } from 'src/app/models/common/response.model';
import { SubjectPaginatedItemViewModel } from "src/app/models/subject/subject.paginated.item.model";

@Injectable({
  providedIn: 'root'
})
export class SubjectService {

  constructor(private httpClient: HttpClient) { }
  getAll(): Observable<SubjectModel[]> {
    return this.httpClient.
      get<SubjectModel[]>(environment.apiUrl + 'Subject');
  }

  saveSubject(vm: SubjectModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'Subject', vm);
  }

  delete(id: number): Observable<ResponseModel> {
    return this.httpClient.
      delete<ResponseModel>(environment.apiUrl + 'Subject/' + id);
  }
  
  getSubjectbyId(id:number): Observable<SubjectModel>{
    return this.httpClient.get<SubjectModel>
        (environment.apiUrl + 'User/getSubjectbyId/'+ id);
  }

  getSubjectList(searchText: string, currentPage: number, pageSize: number):Observable<SubjectPaginatedItemViewModel>{
    return this.httpClient.get<SubjectPaginatedItemViewModel>(environment.apiUrl + "subject/getSubjectList",{
      params:new HttpParams()
        .set('searchText',searchText)
        .set('currentPage', currentPage.toString())
        .set('pageSize', pageSize.toString())
      });
  }
}
