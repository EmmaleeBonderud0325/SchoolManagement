import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseModel } from 'src/app/models/common/response.model';
import { environment } from 'src/environments/environment';
import { SubjectTeacherFilter } from "../../models/subject-teacher/subject.teacher.filter";
import { SubjectTeachersModel } from "../../models/subject-teacher/subject.teachers.model";
import { SubjectTeacherMasterDataModel } from "../../models/subject-teacher/subject.teacher.master.data.model";
import { DropDownModel } from 'src/app/models/common/drop-down.model';

@Injectable({
  providedIn: 'root'
})
export class SubjectTeacherService {

  constructor(private httpClient: HttpClient) { }


  getClassSubjectsForSelectedAcademiclevel(filter: SubjectTeacherFilter): Observable<SubjectTeachersModel[]> {
    return this.httpClient.post<SubjectTeachersModel[]>(environment.apiUrl + "SubjectTeacher/getAllSubjectTeachers", filter);
  }

  saveSubjectTeacher(vm: SubjectTeachersModel): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(environment.apiUrl + "SubjectTeacher/saveSubjectTeacher", vm);
  }

  getSubjectsForSelectedAcademicLevel(academicLevelId: number): Observable<DropDownModel[]> {
    return this.httpClient.get<DropDownModel[]>(environment.apiUrl + "SubjectTeacher/getSubjectsForSelectedAcademicLevel/" + academicLevelId);
  }

  getSubjectTeacherMasterData(): Observable<SubjectTeacherMasterDataModel> {
    return this.httpClient.get<SubjectTeacherMasterDataModel>(environment.apiUrl + "SubjectTeacher/getSubjectTeacherMasterData");
  }

}
