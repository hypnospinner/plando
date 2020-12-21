import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {switchMap} from 'rxjs/operators';
import {Laundry, Order, Status} from '@app/_models';
import {LaundryService, OrdersService} from '@app/_services';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html'
})
export class OrderComponent implements OnInit {
  loading = false;
  errMess: string;
  order: Order;
  laundry: Laundry;
  constructor(private route: ActivatedRoute,
              private ordersService: OrdersService,
              private laundryService: LaundryService,
              private router: Router) { }

  ngOnInit(): void {
      this.loading = true;
      this.route.params.pipe(switchMap((params: Params) => this.ordersService.getOrderById(params['id']) ))
        .subscribe(order => {
            this.order = order;
            this.laundryService.getLaundry(order.laundryId).subscribe(laundry => {
              this.laundry = laundry;
              this.loading = false;
            }, errmess => this.errMess = errmess);
          }, errmess => this.errMess = (errmess as any));
  }
  cancelOrder() {
    if (this.order.status === 'new'){
      this.ordersService.cancelOrder(this.order.id)
        .subscribe(resp => {
          const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/orders';
          this.router.navigateByUrl(returnUrl);
        });
    }
  }
  passOrder() {
    if (this.order.status === 'finished'){
      this.ordersService.passOrder(this.order.id);
    }
  }
}
