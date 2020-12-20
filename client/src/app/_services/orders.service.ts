import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {Order} from '@app/_models';
import {HttpClient} from '@angular/common/http';
import {environment} from '@environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  constructor(private http: HttpClient) {}
  getOrders(): Observable<Order[]>{
    return this.http.get<Order[]>(`${environment.apiUrl}/order`);
  }
}
