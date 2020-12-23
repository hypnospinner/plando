import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {Order, ServiceInOrder} from '@app/_models';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {environment} from '@environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  constructor(private http: HttpClient) {}
  getOrders(): Observable<Order[]>{
    return this.http.get<Order[]>(`${environment.apiUrl}/orders`);
  }
  getOrderById(id: any): Observable<Order>{
    return this.http.get<Order>(`${environment.apiUrl}/order/${id}`);
  }
  addService(serviceId, orderId): Observable<ServiceInOrder> {
    return this.http.post<ServiceInOrder>(`${environment.apiUrl}/order/service/add`, {serviceId, orderId});
  }
  removeService(serviceId, orderId){
    return this.http.post(`${environment.apiUrl}/order/service/remove`, {serviceId, orderId});
  }
  completeService(serviceId, orderId){
    return this.http.post(`${environment.apiUrl}/order/service/complete`, {serviceId, orderId});
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
