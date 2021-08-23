import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AcademicYearModel } from 'src/app/models/academic-Year/academic.Year.model';
import { ResponseModel } from 'src/app/models/common/response.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AcademicYearService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<AcademicYearModel[]> {
    return this.httpClient.
      get<AcademicYearModel[]>(environment.apiUrl + 'AcademicYear');
  }

  save(vm: AcademicYearModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'AcademicYear', vm);
  }

  delete(id: number): Observable<ResponseModel> {
    return this.httpClient.
      delete<ResponseModel>(environment.apiUrl + 'AcademicYear/' + id);
  }
}
