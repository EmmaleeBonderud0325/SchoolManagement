import { ResponseModel } from '../../models/common/response.model';
import { environment } from '../../../environments/environment';
import { ClassModel} from '../../models/class/class.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class ClassService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<ClassModel[]>{
    return this.httpClient.
      get<ClassModel[]>(environment.apiUrl + 'Class')
  }


  save(vm: ClassModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'class/saveClass', vm);
  }
  
}
