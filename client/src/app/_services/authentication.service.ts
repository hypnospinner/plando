import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '@environments/environment';
import { User } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private tokenSubject: BehaviorSubject<string>;
    public token: Observable<string>;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.tokenSubject = new BehaviorSubject<string>(localStorage.getItem('token'));
        this.token = this.tokenSubject.asObservable();
    }

    public get tokenValue(): string {
        return this.tokenSubject.getValue();
    }

    register(email: string, password: string) {
      return this.http.post<any>(`${environment.apiUrl}/auth/register`, { email, password })
        .pipe( map(token => {
            localStorage.setItem('token', token);
            this.tokenSubject.next(token);
            return token;
        }));
    }
    registerManager(email: string, password: string) {
      return this.http.post<any>(`${environment.apiUrl}/auth/register/manager`, { email, password })
    }
    login(email: string, password: string) {
        return this.http.post<any>(`${environment.apiUrl}/auth/login`, { email, password })
            .pipe(map(token => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('token', token);
                this.tokenSubject.next(token);
                return token;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('token');
        this.tokenSubject.next(null);
        this.router.navigate(['/login']);
    }
}
