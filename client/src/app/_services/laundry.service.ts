import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Laundry } from '@app/_models';
import { environment } from '@environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LaundryService {
  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Laundry[]>(`${environment.apiUrl}/admin/laundries`);
  }
}
