import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SubjectModel } from './../../models/subject/subject.model';
import { environment } from 'src/environments/environment';
import { ResponseModel } from 'src/app/models/common/response.model';

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
}
