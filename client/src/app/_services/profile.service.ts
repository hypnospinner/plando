import { Injectable } from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';
import {User} from '@app/_models';
import {environment} from '@environments/environment';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  private userSubject: BehaviorSubject<User>;
  public user: Observable<User>;

  constructor(private http: HttpClient) { }
  getProfile(): Observable<User>{
    return this.http.get<User>(`${environment.apiUrl}/profile`);
  }
}
