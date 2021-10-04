import { environment } from 'src/environments/environment';
import { DropDownModel } from './../../models/common/drop-down.model';
import { LessonModel } from './../../models/lesson/lesson.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ResponseModel } from '../../models/common/response.model';
import {Observable, Subject } from 'rxjs';
import { Injectable } from '@angular/core';
import { id } from '@swimlane/ngx-datatable';
import { LessonFilterModel } from 'src/app/models/lesson/lesson.filter.model';
import { LessonMasterDataModel } from "src/app/models/lesson/lesson.masterdata.model";
import { LessonPaginatedItemsViewModel } from "src/app/models/lesson/lesson.paginated.items";
import { LessonTopicModel } from 'src/app/models/lesson/lesson.topic.model';
import { TopicContentModel } from 'src/app/models/lesson/topic.content';
;

@Injectable({
  providedIn: 'root'
})
export class LessonService {
 
  onLessonDetailAssigned:Subject<any>;

  constructor(private httpClient: HttpClient) 
  { 
    this.onLessonDetailAssigned = new Subject();
  }

  getAllLessonList(searchText:string, academicYearId:number, academicLevelId:number,classNameId:number,subjectId:number,currentPage: number, pageSize: number): Observable<LessonPaginatedItemsViewModel>{
    return this.httpClient
        .get<LessonPaginatedItemsViewModel>(environment.apiUrl +"LessonDesign/getLessonList",{
          params: new HttpParams()
            .set('searchText',searchText)
            .set('academicLevelId',academicLevelId.toString())
            .set('academicYearId', academicYearId.toString())
            .set('classNameId', classNameId.toString())
            .set('subjectId',subjectId.toString())
            .set('currentPage', currentPage.toString())
            .set('pageSize', pageSize.toString())
        });
  }

  createNewLesson(): Observable<LessonModel> {
    return this.httpClient.post<LessonModel>
    (environment.apiUrl +'LessonDesign/createNewLesson',null);
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

   ///get user by id Service
   getLessonById(id:number): Observable<LessonModel>{
    return this.httpClient.get<LessonModel>
        (environment.apiUrl + 'LessonDesign/getLessonById/'+ id);
  }

  saveTopic(vm :LessonTopicModel): Observable <LessonTopicModel>{
    return this.httpClient
      .post<LessonTopicModel>(environment.apiUrl + 'LessonDesign/saveTopic', vm);
 
  }

  saveTopicContent(vm :TopicContentModel): Observable <TopicContentModel>{
    return this.httpClient
      .post<TopicContentModel>(environment.apiUrl + 'LessonDesign/saveTopicContent', vm);
 
  }
  
}
