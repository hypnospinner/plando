import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Laundry } from '@app/_models';
import { environment } from '@environments/environment';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LaundryService {
  constructor(private http: HttpClient) { }

  getAll(): Observable<Laundry[]> {
    return this.http.get<Laundry[]>(`${environment.apiUrl}/admin/laundries`);
  }

  getLaundry(id: string): Observable<Laundry> {
    return this.http.get<Laundry>(`${environment.apiUrl}/admin/laundry/${id}`);
  }
}
