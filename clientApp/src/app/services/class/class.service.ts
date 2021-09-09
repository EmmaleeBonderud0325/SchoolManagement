import { DropDownModel } from './../../models/common/drop-down.model';
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
      get<ClassModel[]>(environment.apiUrl + 'Class/getClasses')
  }

  saveClass(vm: ClassModel): Observable<ResponseModel> {
    console.log("service call")
    return this.httpClient.
      post<ResponseModel>
      (environment.apiUrl + 'Class/savaClass', vm);
      
  }

  delete(classNameId: number): Observable<ResponseModel> {
    return this.httpClient.
      delete<ResponseModel>(environment.apiUrl + 'Class/' + classNameId);
  }
  
  getAllClassNames():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'Class/getAllClassNames');
  }

  getAllAcademicLevels():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'Class/getAllAcademicLevels');
  }

  getAllAcademicYears():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'Class/getAllAcademicYears');
  }

  getAllClassCategories():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'Class/getAllClassCategories');
  }

  getAllLanguageStreams():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'Class/getAllLanguageStreams');
  }
  
}
