import { environment } from 'src/environments/environment';
import { LessonModel } from './../../models/lesson/lesson.model';
import { HttpClient } from '@angular/common/http';
import { ResponseModel } from '../../models/common/response.model';
import {Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { id } from '@swimlane/ngx-datatable';
;

@Injectable({
  providedIn: 'root'
})
export class LessonService {
 
  
  
  constructor(private httpClient: HttpClient) { }

   getAllLesson(LessonFilterModel): Observable<LessonModel>{
    return this.httpClient
        .post<LessonModel>(environment.apiUrl +'LessonDesign/getAllLessons',LessonFilterModel);
  } 

  delete(id: number): Observable <ResponseModel> { 
          return this.httpClient
            .delete<ResponseModel>(environment.apiUrl + 'LessonDesign/' + id); 
  }       

  saveLesson(vm, LessonModel): Observable <ResponseModel>{
           return this.httpClient
              .post<ResponseModel>(environment.apiUrl + 'LessonDesign', vm);
  
        
 
  }
}
