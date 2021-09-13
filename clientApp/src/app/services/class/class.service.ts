import { DropDownModel } from './../../models/common/drop-down.model';
import { ResponseModel } from '../../models/common/response.model';
import { environment } from '../../../environments/environment';
import { ClassModel } from '../../models/class/class.model';
import { ClassPaginatedItemsViewModel } from "../../models/class/class.paginated.items.model";
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserModel } from 'src/app/models/user/user.model';
import { ClassMasterDataModel } from "../../models/class/class.masterdata.model";
import { ClassSubjectTeacherModel } from 'src/app/models/class/class.subject.teacher.model';


@Injectable({
  providedIn: 'root'
})

export class ClassService {

  constructor(private httpClient: HttpClient) { }

  getClassList(searchText: string, currentPage: number, pageSize: number, academicYearId: number, academicLevelId: number): Observable<ClassPaginatedItemsViewModel> {
    return this.httpClient.get<ClassPaginatedItemsViewModel>(environment.apiUrl + "Class/getClassList", {
      params: new HttpParams()
        .set('searchText', searchText)
        .set('currentPage', currentPage.toString())
        .set('pageSize', pageSize.toString())
        .set('academicYearId', academicYearId.toString())
        .set('academicLevelId', academicLevelId.toString())
    });
  }

  getClassDetails(academicYearId: number, academicLevelId: number, classNameId: number): Observable<ClassModel> {
    return this.httpClient.get<ClassModel>(environment.apiUrl + "Class/getClassDetails/" + academicYearId + "/" + academicLevelId + "/" + classNameId);
  }

  getClassSubjectsForSelectedAcademiclevel(academicYearId: number, academicLevelId: number): Observable<ClassSubjectTeacherModel[]> {
    return this.httpClient.get<ClassSubjectTeacherModel[]>(environment.apiUrl + "Class/getClassSubjectsForSelectedAcademiclevel/" + academicYearId + "/" + academicLevelId);
  }

  saveClassDetail(vm: ClassModel): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(environment.apiUrl + "Class/saveClassDetail", vm);
  }

  deleteClass(academicYearId: number, academicLevelId: number, classNameId: number): Observable<ResponseModel> {
    return this.httpClient.delete<ResponseModel>(environment.apiUrl + "Class/deleteClass/" + academicYearId + "/" + academicLevelId + "/" + classNameId);
  }

  getClassMasterData(): Observable<ClassMasterDataModel> {
    return this.httpClient.get<ClassMasterDataModel>(environment.apiUrl + "Class/getClassMasterData");
  }

}
