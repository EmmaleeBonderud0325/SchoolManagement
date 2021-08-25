import { ResponseModel } from '../../models/common/response.model';
import { environment } from '../../../environments/environment';
import { classnameModel } from '../../models/class-name/classname.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class ClassNameService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<classnameModel[]>{
    return this.httpClient.
      get<classnameModel[]>(environment.apiUrl + 'ClassName')
  }

  save(vm: classnameModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'ClassName', vm);
  }

  delete(id: number): Observable<ResponseModel> {
    return this.httpClient.
      delete<ResponseModel>(environment.apiUrl + 'ClassName/' + id);
  }
  
}
