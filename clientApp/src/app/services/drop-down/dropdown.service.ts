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
}
