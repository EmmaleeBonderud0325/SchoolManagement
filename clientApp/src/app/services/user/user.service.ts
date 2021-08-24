import { DropDownModel } from './../../models/common/drop-down.model';
import { ResponseModel } from './../../models/common/response.model';
import { environment } from './../../../environments/environment';
import { UserModel } from './../../models/user/user.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<UserModel[]>{
    return this.httpClient.
      get<UserModel[]>(environment.apiUrl + 'User')
  }

  saveUser(user: UserModel): Observable<ResponseModel> {
    return this.httpClient.
      post<ResponseModel>(environment.apiUrl + 'User/SaveUser', user);
  }

  getUserById(id:number): Observable<UserModel>{
    return this.httpClient.get<UserModel>(environment.apiUrl + 'User/GetUserById/'+ id);
  }

  getAllRoles(): Observable<DropDownModel[]>{
    return this.httpClient.
      get<DropDownModel[]>(environment.apiUrl + 'User/getAllRoles')
  }
  
}
