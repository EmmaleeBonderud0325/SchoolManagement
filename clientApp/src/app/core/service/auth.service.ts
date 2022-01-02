import { ResetPasswordModel } from './../../models/auth/reset.password.model';
import { ResponseModel } from './../../models/common/response.model';
import { ForgotPasswordModel } from './../../models/user/forgot.password.model';
import { LoginModel } from './../../models/auth/login.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(private httpClient: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(
      JSON.parse(localStorage.getItem('currentUser'))
    );
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  login(loginModel: LoginModel): Observable<any> {
    return this.httpClient.post<any>(environment.apiUrl + 'Auth/login', loginModel)
    .pipe(
      map((user) => {
       
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
        return user;
      })
    );
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
    return of({ success: false });
  }

   //forgotPassword
   forgotPassword(vm:ForgotPasswordModel):Observable<ResponseModel>{
    return this.httpClient.
      post<ResponseModel>
        (environment.apiUrl+ 'Auth/forgotPassword', vm);
  }
  //ResetPassword
  resetPassword(vm:ResetPasswordModel):Observable<ResponseModel>{
    return this.httpClient.
      post<ResponseModel>
        (environment.apiUrl+ 'Auth/resetPassword', vm);
  }
}
