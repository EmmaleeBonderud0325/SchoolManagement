import { environment } from './../../../environments/environment';
import { Observable } from 'rxjs';
import { LoginModel } from './../../models/auth/login.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router,private httpClient: HttpClient) { }

  
  login(loginModel: LoginModel): Observable<any> {
    return this.httpClient.post<any>(environment.apiUrl + 'Auth/webAppLogin', loginModel);
  }

  isLoggedInUser() {
    const userSession = localStorage.getItem('currentUser');
    if (userSession) {
      return true;
    } else {
      return false;
    }
  }

  signOut() {
    const userSession = localStorage.getItem('currentUser');
    if (userSession) {
      localStorage.removeItem('currentUser');
      localStorage.removeItem('IsEEGUserLoggedIn');
    }

    this.router.navigate(['/pages/auth/login']);
  }
}
