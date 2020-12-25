import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {switchMap} from 'rxjs/operators';
import {Laundry, Order, Role, Service, ServiceInOrder, User} from '@app/_models';
import {LaundryService, OrdersService, ProfileService} from '@app/_services';
import {HttpResponse} from '@angular/common/http';
import {Observable} from 'rxjs';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html'
})
export class OrderComponent implements OnInit {
  loading = false;
  loadingProfile = false;
  errMess: string;
  user: User;
  order: Order;
  laundry: Laundry;
  selectedServices: Set<ServiceInOrder>;
  availableServices: Set<Service>;
  constructor(private route: ActivatedRoute,
              private ordersService: OrdersService,
              private laundryService: LaundryService,
              private router: Router,
              private profileService: ProfileService) { }

  ngOnInit(): void {
      this.loading = true;
      this.loadingProfile = true;
      this.availableServices = new Set<Service>();
      this.route.params.pipe(switchMap((params: Params) => this.ordersService.getOrderById(params['id']) ))
        .subscribe(order => {
            this.order = order;
            this.selectedServices = new Set<ServiceInOrder>(this.order.services);
            this.laundryService.getLaundry(order.laundryId).subscribe(laundry => {
              this.laundry = laundry;
              this.laundry.services.forEach(enabledService => {
                let idx = this.order.services.findIndex((item, index, array) => {
                  return item.id === enabledService.service.id;
                });
                if (idx === -1){
                  this.availableServices.add(enabledService.service);
                }
              });
              this.loading = false;
            }, errmess => {
              this.errMess = errmess;
              const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/orders';
              this.router.navigateByUrl(returnUrl);
            });
          }, errmess => {
          this.errMess = errmess as any;
          const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/orders';
          this.router.navigateByUrl(returnUrl);
        });
      this.profileService.getProfile()
        .subscribe(user => {
          this.user = user;
          this.loadingProfile = false;
        }, error => this.errMess = error);
  }
  removeService(serviceId, orderId){
    if (this.order.status !== 'new') {
      return;
    }
    this.ordersService.removeService(serviceId, orderId)
      .subscribe(service => {
        let elForRemove = Array.from(this.selectedServices)[Array.from(this.selectedServices).findIndex((item) => {
          return item.id === serviceId;
        })];
        this.selectedServices.delete(elForRemove);
        let elForBack = this.laundry.services[this.laundry.services.findIndex((item) => {
          return item.service.id === serviceId;
        })].service;
        this.availableServices.add(elForBack);
      });
  }
  addService(serviceId, orderId) {
    if (this.order.status !== 'new') {
      return;
    }
    this.ordersService.addService(serviceId, orderId)
      .subscribe(service => {
        let el = Array.from(this.availableServices)[Array.from(this.availableServices).findIndex((item) => {
          return item.id === serviceId;
        })];
        this.availableServices.delete(el);
        if (service){
          this.selectedServices.add(service);
        } else {
          let newServiceInOrder = new ServiceInOrder();
          newServiceInOrder.id = serviceId;
          newServiceInOrder.name = el.title;
          newServiceInOrder.price = el.price;
          this.selectedServices.add(newServiceInOrder);
        }
      });
  }
  cancelOrder() {
    if (this.user && this.user.role === Role.Client && this.order.status === 'new'){
      this.ordersService.cancelOrder(this.order.id)
        .subscribe(resp => {
          const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/orders';
          this.router.navigateByUrl(returnUrl);
        }, error => this.errMess = error);
    }
  }
  progressOrder(){
    if (this.user && this.user.role === Role.Manager && this.order.status === 'new'){
      this.ordersService.progressOrder(this.order.id)
        .subscribe(resp => {
          this.order.status = 'iN_PROGRESS';
        }, error => this.errMess = error);
    }
  }
  finishOrder(){
    if (this.user && this.user.role === Role.Manager && this.order.status === 'iN_PROGRESS'){
      this.ordersService.finishOrder(this.order.id)
        .subscribe(resp => {
          this.order.status = 'finished';
        }, error => this.errMess = error);
    }

  }
  passOrder() {
    if (this.user && this.user.role === Role.Client && this.order.status === 'finished'){
      this.ordersService.passOrder(this.order.id)
        .subscribe(resp => {
          this.order.status = 'passed';
        }, error => this.errMess = error);
    }
  }
}
