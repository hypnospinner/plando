import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {switchMap} from 'rxjs/operators';
import {Laundry, Order, Role, User} from '@app/_models';
import {LaundryService, OrdersService, ProfileService} from '@app/_services';

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

  constructor(private route: ActivatedRoute,
              private ordersService: OrdersService,
              private laundryService: LaundryService,
              private router: Router,
              private profileService: ProfileService) { }

  ngOnInit(): void {
      this.loading = true;
      this.loadingProfile = true;
      this.route.params.pipe(switchMap((params: Params) => this.ordersService.getOrderById(params['id']) ))
        .subscribe(order => {
            this.order = order;
            this.laundryService.getLaundry(order.laundryId).subscribe(laundry => {
              this.laundry = laundry;
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
