import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseModel } from 'src/app/models/common/response.model';
import { environment } from 'src/environments/environment';
import { LessonAssignmentModel } from '../../models/lesson-assignment/lesson.assignment.model';

@Injectable({
  providedIn: 'root'
})
export class LessonAssignmentService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<LessonAssignmentModel[]>{
    return this.httpClient.
      get<LessonAssignmentModel[]>(environment.apiUrl + 'lesson-assignment')
  }

  saveLessonAssignment(lessonassignment: LessonAssignmentModel): Observable<ResponseModel> {​​​​​​​​
    return this.httpClient.
    post<ResponseModel>(environment.apiUrl + 'lesson-assignment/saveLessonAssignment', lessonassignment);

  //save(vm: LessonAssignmentModel): Observable<ResponseModel> {
    //return this.httpClient.
      //post<ResponseModel>(environment.apiUrl + 'class/saveClass', vm);
  }  
  
    delete(Id: number): Observable<ResponseModel> { 
    return this.httpClient.
     delete<ResponseModel>(environment.apiUrl + 'lesson-assignment' + Id);
     }


  
}

