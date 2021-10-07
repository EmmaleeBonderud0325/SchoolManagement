import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ReportService {

  constructor(private httpClient: HttpClient) { }

  downloadUserList(vm:ReportTypeModel): Observable<any> {
    return this.httpClient.get<any>
    (environment.apiUrl +'User/downloadUserList');
  }

  /*downloadUserList(path: string): Observable<any> {
    return this.httpClient.post(`${environment.apiUrl}/accountVerification/downloadFile`, { path: path }, {
        observe: 'response',
        responseType: 'blob'
    });
}
}

