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

  saveClassName(classname: classnameModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'class-name/saveClassName', classname);
  }
  
}
