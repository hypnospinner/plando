import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '@environments/environment';
import {Service} from '@app/_models';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  constructor(private http: HttpClient) { }
  addService(service: Service){
    const serviceMap = new Map(Object.entries(service));
    return this.http.post(`${environment.apiUrl}/service/add`, serviceMap);
  }
  enableService(serviceId, laundryId){
    return this.http.post(`${environment.apiUrl}/service/enable`, {serviceId, laundryId});
  }
  getAll(): Observable<Service[]> {
    return this.http.get<Service[]>(`${environment.apiUrl}/services`);
  }
}
