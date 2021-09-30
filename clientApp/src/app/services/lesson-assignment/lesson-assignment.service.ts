import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DropDownModel } from 'src/app/models/common/drop-down.model';
import { ResponseModel } from 'src/app/models/common/response.model';
import { LessonAssignmentPaginatedItemsViewModel } from 'src/app/models/lesson-assignment/lesson.assignment.paginated.items';
import { environment } from 'src/environments/environment';
import { LessonAssignmentModel } from '../../models/lesson-assignment/lesson.assignment.model';

@Injectable({
  providedIn: 'root'
})
export class LessonAssignmentService {
  uploadFile(formData: any) {
    throw new Error("Method not implemented.");
  }

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
  

        getLessonList(searchText: string, currentPage: number, pageSize: number, lessonId:number,):Observable<LessonAssignmentPaginatedItemsViewModel>{
        return this.httpClient.get<LessonAssignmentPaginatedItemsViewModel>(environment.apiUrl + "LessonAssignment/getLessonList",{
          params:new HttpParams()
            .set('searchText',searchText)
            .set('currentPage', currentPage.toString())
            .set('pageSize', pageSize.toString())
            .set('lessonId', lessonId.toString())
    
        });
    
      }  
}

