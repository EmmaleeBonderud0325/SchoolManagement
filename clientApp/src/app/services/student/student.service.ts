import { upload, Upload } from './../../models/common/upload';
import { HttpClient } from '@angular/common/http';
import { StudentModel } from './../../models/student/student.model'
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseModel } from 'src/app/models/common/response.model';
import { DropDownModel } from 'src/app/models/common/drop-down.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<StudentModel[]> {
    return this.httpClient.
      get<StudentModel[]>(environment.apiUrl + 'Student');
  }

  saveStudent(vm: StudentModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'Student', vm);
  }

  getAllGenders():Observable<DropDownModel[]> {
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'Student/getAllGenders');
  }

  delete(id: number): Observable<ResponseModel> {
    return this.httpClient.
      delete<ResponseModel>(environment.apiUrl + 'Student/' + id);
  }

  uploadClassStudents(data: FormData): Observable<Upload> {
    return this.httpClient.post(environment.apiUrl +'Student/uploadClassStudents', data,{reportProgress: true,observe: 'events'}).pipe(upload());
  }
}
