import { ForgotPasswordModel } from './../../models/user/forgot.password.model';
import { UserMasterDataModel } from './../../models/user/user.master.data';
import { DropDownModel } from './../../models/common/drop-down.model';
import { ResponseModel } from './../../models/common/response.model';
import { environment } from './../../../environments/environment';
import { UserModel } from './../../models/user/user.model';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserPaginatedItemViewModel } from "src/app/models/user/user.paginated.item.model";
import { UserMasterModel } from "src/app/models/user/user.master";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }
  
  //get All user service
  getAll(): Observable<UserModel[]>{
    return this.httpClient.
      get<UserModel[]>
        (environment.apiUrl + 'User/getAllUsers')
  }

  //Save user service
  saveUser(vm: UserModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>
        (environment.apiUrl + 'User', vm);
  }

  getClassMasterData(): Observable<UserMasterDataModel> {
    return this.httpClient
    .get<UserMasterDataModel>(environment.apiUrl + "User/getUserMasterData");
  }

  getUserList(searchText: string, currentPage: number, pageSize: number, roleId:number,):Observable<UserPaginatedItemViewModel>{
    return this.httpClient.get<UserPaginatedItemViewModel>(environment.apiUrl + "User/getUserList",{
      params:new HttpParams()
        .set('searchText',searchText)
        .set('currentPage', currentPage.toString())
        .set('pageSize', pageSize.toString())
        .set('roleId', roleId.toString())
    });
  }

  ///get user by id Service
  getUserById(id:number): Observable<UserModel>{
    return this.httpClient.get<UserModel>
        (environment.apiUrl + 'User/getUserById/'+ id);
  }

  //get user Roles Service 
  getAllRoles(): Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>
        (environment.apiUrl + 'User/getAllRoles')
  }

  //User Delete Service
  delete(id: number): Observable<ResponseModel> {
    return this.httpClient.
      delete<ResponseModel>
        (environment.apiUrl + 'User/' + id);
  }

  //getUserDetails
  getUserDetails():Observable<UserMasterModel>{
    return this.httpClient.
      get<UserMasterModel>
        (environment.apiUrl + 'User/getUserDetail');

  }
  //updateUserProfile
  UpdateUserMasterData(vm:UserMasterModel):Observable<ResponseModel>{
    return this.httpClient.
      post<ResponseModel>
        (environment.apiUrl+ 'User/updateUserMasterData', vm);
  }
  
  downloadUserListReport(): Observable<any> {
    return this.httpClient.post<any>
    (environment.apiUrl +'Report/downloadClassAttendanceForAllSubjects',{headers:{'filedownload':''}, observe: 'events',reportProgress:true });
  }

  
}
