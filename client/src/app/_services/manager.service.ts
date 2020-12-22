import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {User} from '@app/_models';
import {HttpClient} from '@angular/common/http';
import {environment} from '@environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ManagerService {

  constructor(private http: HttpClient) { }

  getFreeManagers(): Observable<User[]>{
    return this.http.get<User[]>(`${environment.apiUrl}/users/freeManagers`);
  }
  getBusyManagers(): Observable<User[]>{
    return this.http.get<User[]>(`${environment.apiUrl}/users/busyManagers`);
  }
  dismiss(managerId) {
    return this.http.post(`${environment.apiUrl}/laundry/dismiss`, {managerId});
  }
  employ(managerId, laundryId) {
    return this.http.post(`${environment.apiUrl}/laundry/employ`, {managerId, laundryId});
  }
}
