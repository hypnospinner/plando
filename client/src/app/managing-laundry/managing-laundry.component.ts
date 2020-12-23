import { Component, OnInit } from '@angular/core';
import {LaundryService, OrdersService, ProfileService, ServiceService} from '@app/_services';
import {Laundry, Order, Service, User} from '@app/_models';

@Component({
  selector: 'app-managing-laundry',
  templateUrl: './managing-laundry.component.html'
})
export class ManagingLaundryComponent implements OnInit {
  me: User;
  laundry: Laundry;
  orders: Order[];
  loadingOrders = false;
  services: Service[];
  loadingServices = false;
  loading = false;
  errMess: string;
  constructor(private profileService: ProfileService,
              private orderService: OrdersService,
              private serviceService: ServiceService,
              private laundryService: LaundryService) { }

  ngOnInit(): void {
    this.loading = true;
    this.profileService.getProfile()
      .subscribe(profile => {
        this.me = profile;
        this.laundryService.getLaundry(this.me.laundryId)
          .subscribe(laundry => {
            this.laundry = laundry;
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
    this.serviceService.getAll()
      .subscribe(services => {
        this.services = services;
        this.loadingServices = false;
      }, error => this.errMess = error);
  }

}
