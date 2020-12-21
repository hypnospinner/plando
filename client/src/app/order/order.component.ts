import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Params} from '@angular/router';
import {switchMap} from 'rxjs/operators';
import {Order} from '@app/_models';
import {OrdersService} from '@app/_services';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html'
})
export class OrderComponent implements OnInit {
  loading = false;
  errMess: string;
  order: Order;
  constructor(private route: ActivatedRoute,
              private ordersService: OrdersService) { }

  ngOnInit(): void {
      this.loading = true;
      this.route.params.pipe(switchMap((params: Params) => this.ordersService.getOrderById(params['id']) ))
        .subscribe(order => {
            this.order = order;
            this.loading = false;
          },
          errmess => this.errMess = (errmess as any));
  }

}
