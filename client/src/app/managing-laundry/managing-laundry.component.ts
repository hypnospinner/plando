import { Component, OnInit } from '@angular/core';
import {LaundryService, OrdersService, ProfileService, ServiceService} from '@app/_services';
import {EnabledService, Laundry, Order, Service, User} from '@app/_models';

@Component({
  selector: 'app-managing-laundry',
  templateUrl: './managing-laundry.component.html'
})
export class ManagingLaundryComponent implements OnInit {
  me: User;
  laundry: Laundry;
  orders: Order[];
  loadingOrders = false;
  services: EnabledService[];
  loadingServices = false;
  loading = false;
  errMess: string;
  availableServices: Set<Service>;
  constructor(private profileService: ProfileService,
              private orderService: OrdersService,
              private serviceService: ServiceService,
              private laundryService: LaundryService) { }

  ngOnInit(): void {
    this.loading = true;
    this.availableServices = new Set<Service>();
    this.profileService.getProfile()
      .subscribe(profile => {
        this.me = profile;
        this.laundryService.getLaundry(this.me.laundryId)
          .subscribe(laundry => {
            this.laundry = laundry;
            this.services = this.laundry.services;
            this.serviceService.getAll()
              .subscribe(allServices => {
                console.log(allServices);
                allServices.forEach(service => {
                  if (this.services.findIndex((item, index, array) => {
                    return item.service.id === service.id;
                  }) === -1){
                    this.availableServices.add(service);
                  }
                });
              }, error => this.errMess = error);
            this.loading = false;
          }, error => this.errMess = error);
      }, error => this.errMess = error);
    this.loadingOrders = true;
    this.orderService.getOrders()
      .subscribe(orders => {
        this.orders = orders;
        this.loadingOrders = false;
      }, error => this.errMess = error);
    this.loadingServices = true;
  }

  enableService(serviceId, laundryId){
    this.serviceService.enableService(serviceId, laundryId)
      .subscribe(resp => {
        window.location.reload();
      }, error => this.errMess = error);
  }
}
