import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
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
      get<LessonAssignmentModel[]>(environment.apiUrl + 'LessonAssignment')
  }

  saveLessonAssignment(lessonassignment: LessonAssignmentModel): Observable<ResponseModel> {​​​​​​​​
    return this.httpClient.
    post<ResponseModel>(environment.apiUrl + 'LessonAssignment/', lessonassignment);

  //save(vm: LessonAssignmentModel): Observable<ResponseModel> {
    //return this.httpClient.
      //post<ResponseModel>(environment.apiUrl + 'class/saveClass', vm);
  }  
  
  delete(Id: number): Observable<ResponseModel> { 
    return this.httpClient.
     delete<ResponseModel>(environment.apiUrl + 'LessonAssignment/' + Id);
     }

     getAllLessons():Observable<DropDownModel[]>{
      return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'LessonAssignment/getAllLessons');
      }
  
}

