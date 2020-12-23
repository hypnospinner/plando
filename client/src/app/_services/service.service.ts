import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '@environments/environment';
import {Service} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  constructor(private http: HttpClient) { }
  addService(service: Service){
    const serviceMap = new Map(Object.entries(service));
    this.http.post(`${environment.apiUrl}/service/add`, serviceMap);
  }
  enableService(serviceId, laundryId){
    this.http.post(`${environment.apiUrl}/service/enable`, {serviceId, laundryId});
  }
  getAll(){
    this.http.get(`${environment.apiUrl}/services`);
  }
}
