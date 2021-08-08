import { environment } from 'src/environments/environment';
import { LessonModel } from './../../models/lesson/lesson.model';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject,Observable } from 'rxjs';
import { Injectable } from '@angular/core';
;

@Injectable({
  providedIn: 'root'
})
export class LessonService {
  
  constructor(private httpClient: HttpClient) { }

  getAllLesson(): Observable<LessonModel>{
    return this.httpClient
        .get<LessonModel>(environment.apiUrl + '/Lesson' );
  }

}
