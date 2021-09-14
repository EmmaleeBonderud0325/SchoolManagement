import { environment } from 'src/environments/environment';
import { LessonModel } from './../../models/lesson/lesson.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ResponseModel } from '../../models/common/response.model';
import {Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { id } from '@swimlane/ngx-datatable';
import { LessonFilterModel } from 'src/app/models/lesson/lesson.filter.model';
import { LessonMasterDataModel } from "src/app/models/lesson/lesson.masterdata.model";
import { LessonPaginatedItemsViewModel } from "src/app/models/lesson/lesson.paginated.items";
;

@Injectable({
  providedIn: 'root'
})
export class LessonService {
 
  constructor(private httpClient: HttpClient) { }

  getAllLessonList(filter:LessonFilterModel,currentPage: number, pageSize: number): Observable<LessonPaginatedItemsViewModel>{
    return this.httpClient
        .get<LessonPaginatedItemsViewModel>(environment.apiUrl +"LessonDesign/getLessonList",{
          params: new HttpParams()
            .set('searchText',filter.searchText)
            .set('selectedAcademicLevelId', filter.selectedAcademicLevelId.toString())
            .set('selectedAcademicYearId', filter.selectedAcademicYearId.toString())
            .set('selectedClassNameId', filter.selectedClassNameId.toString())
            .set('selectedSubjectId',filter.selectedSubjectId.toString())
            .set('currentPage', currentPage.toString())
            .set('pageSize', pageSize.toString())
          
        });
  }

  delete(id: number): Observable <ResponseModel> { 
          return this.httpClient
            .delete<ResponseModel>(environment.apiUrl + 'LessonDesign/' + id); 
  }       

  saveLesson(vm :LessonModel): Observable <ResponseModel>{
           return this.httpClient
              .post<ResponseModel>(environment.apiUrl + 'LessonDesign', vm);
 
  }

  getLessonMasterData(): Observable<LessonMasterDataModel> {
    return this.httpClient
    .get<LessonMasterDataModel>(environment.apiUrl + "LessonDesign/getLessonMasterData");
  }
}
