import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { baseURL } from '../shared/baseurl';
import { ProcessHTTPMsgService } from './process-httpmsg.service';

interface AuthResponse {
  status: string;
  success: string;
  token: string;
}

interface JWTResponse {
  status: string;
  success: string;
  user: any;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  tokenKey = 'JWT';
  isAuthenticated = false;
  username: Subject<string> = new Subject<string>();
  authToken?: string = undefined;

  constructor(private http: HttpClient,
              private processHTTPMsgService: ProcessHTTPMsgService) {
  }

  checkJWTtoken(): void {
    this.http.get<JWTResponse>(baseURL + 'users/checkJWTtoken')
      .subscribe(res => {
          console.log('JWT Token Valid: ', res);
          this.sendUsername(res.user.username);
        },
        err => {
          console.log('JWT Token invalid: ', err);
          this.destroyUserCredentials();
        });
  }

  sendUsername(name: string): void {
    this.username.next(name);
  }

  clearUsername(): void {
    this.username.next(undefined);
  }

  loadUserCredentials(): void {
    const credentials = JSON.parse(localStorage.getItem(this.tokenKey) as string);
    console.log('loadUserCredentials ', credentials);
    if (credentials && credentials.username !== undefined) {
      this.useCredentials(credentials);
      if (this.authToken) {
        this.checkJWTtoken();
      }
    }
  }

  storeUserCredentials(credentials: any): void {
    console.log('storeUserCredentials ', credentials);
    localStorage.setItem(this.tokenKey, JSON.stringify(credentials));
    this.useCredentials(credentials);
  }

  useCredentials(credentials: any): void {
    this.isAuthenticated = true;
    this.sendUsername(credentials.username);
    this.authToken = credentials.token;
  }

  destroyUserCredentials(): void {
    this.authToken = undefined;
    this.clearUsername();
    this.isAuthenticated = false;
    localStorage.removeItem(this.tokenKey);
  }

  signUp(user: any): Observable<any> {
    return this.http.post<AuthResponse>(baseURL + 'users/signup',
      {username: user.username, password: user.password})
      .pipe( map(res => {
          this.storeUserCredentials({username: user.username, token: res.token});
          return {success: true, username: user.username };
        }),
        catchError(error => this.processHTTPMsgService.handleError(error)));
  }

  logIn(user: any): Observable<any> {
    return this.http.post<AuthResponse>(baseURL + 'users/login',
      {username: user.username, password: user.password})
      .pipe( map(res => {
          this.storeUserCredentials({username: user.username, token: res.token});
          return {success: true, username: user.username };
        }),
        catchError(error => this.processHTTPMsgService.handleError(error)));
  }

  logOut(): void {
    this.destroyUserCredentials();
  }

  isLoggedIn(): boolean {
    return this.isAuthenticated;
  }

  getUsername(): Observable<string> {
    return this.username.asObservable();
  }

  getToken(): string {
    // @ts-ignore
    return this.authToken;
  }
}
