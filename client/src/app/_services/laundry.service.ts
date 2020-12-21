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
  registerLaundry(address: string): Observable<Laundry>{
    return this.http.post<Laundry>(`${environment.apiUrl}/laundries`, {address});
  }
  getAll(): Observable<Laundry[]> {
    return this.http.get<Laundry[]>(`${environment.apiUrl}/laundries`);
  }
  getLaundry(id: string): Observable<Laundry> {
    const options = {id: id};
    return this.http.get<Laundry>(`${environment.apiUrl}/laundries/${id}`, {params: options});
  }
  deleteLaundry(id: number) {
    return this.http.delete(`${environment.apiUrl}/laundries/${id}`);
  }

}
