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
  getOrderById(id: any): Observable<Order>{
    return this.http.get<Order>(`${environment.apiUrl}/order/${id}`);
  }
  cancelOrder(orderId: any) {
    return this.http.post(`${environment.apiUrl}/order/cancel`, {orderId});
  }
  progressOrder(orderId: any){
    return this.http.post(`${environment.apiUrl}/order/progress`, {orderId});
  }
  finishOrder(orderId: any){
    return this.http.post(`${environment.apiUrl}/order/finish`, {orderId});
  }
  passOrder(orderId: any) {
    return this.http.post(`${environment.apiUrl}/order/pass`, {orderId});
  }
  createOrder(clientId, laundryId, title: string) {
    return this.http.post(`${environment.apiUrl}/order/create`, {
      clientId,
      laundryId,
      title
    });
  }
}