import { environment } from './../../../environments/environment';
import { DropDownModel } from './../../models/common/drop-down.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DropdownService {

  constructor(private httpClient: HttpClient) { }

  getAllSubjectTypes():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'DropDown/getSubjectTypes');
  }

  getAllSubjectCategorys():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'DropDown/getSubjectCategorys');
  }

  getAllParentBasketSubjects(): Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'DropDown/getAllParentBasketSubjects');
  }

  getAllAcademicLevels(): Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'DropDown/getAllAcademicLevels');
  }

  getAllSubjectStreams():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'DropDown/getAllSubjectStreams');
  }

  getAllClassNames():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'DropDown/getAllClassNames');
  }

  getAllAcademicYears():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'DropDown/getAllAcademicYears');
  }

  getAllClassCategories():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'DropDown/getAllClassCategories');
  }

  getAllLanguageStreams():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'DropDown/getAllLanguageStreams');
  }

  getAllTeachers():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'DropDown/getAllTeachers');
  }

  getExcelMasrerData():Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'DropDown/getExcelMasterData');
  }
  
}
