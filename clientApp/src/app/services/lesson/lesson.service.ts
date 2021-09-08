import { environment } from 'src/environments/environment';
import { DropDownModel } from './../../models/common/drop-down.model';
import { LessonModel } from './../../models/lesson/lesson.model';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../models/common/response.model';
import {Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { id } from '@swimlane/ngx-datatable';
import { LessonFilterModel } from 'src/app/models/lesson/lesson.filter.model';
;

@Injectable({
  providedIn: 'root'
})
export class LessonService {
 
  
  
  constructor(private httpClient: HttpClient) { }

   getAllLesson(filter:LessonFilterModel): Observable<LessonModel[]>{
    return this.httpClient
        .post<LessonModel[]>(environment.apiUrl +'LessonDesign/getAllLessons',filter);
  } 

  delete(id: number): Observable <ResponseModel> { 
          return this.httpClient
            .delete<ResponseModel>(environment.apiUrl + 'LessonDesign/' + id); 
  }       

  saveLesson(vm, LessonModel): Observable <ResponseModel>{
           return this.httpClient
              .post<ResponseModel>(environment.apiUrl + 'LessonDesign', vm);
  
   }
   getAllAcademicLevels(): Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'LessonDesign/getAllAcademicLevels');
  }
  getAllAcademicYears(): Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'LessonDesign/getAllAcademicYears');
  }
  getAllSubjects(): Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'LessonDesign/getAllSubjects');
  }
  getAllClassNames(): Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'LessonDesign/getAllClassNames');
  }

   
}
