import { Component, OnInit } from '@angular/core';
import {AuthenticationService} from '@app/_services';
import {OrdersService} from '@app/_services/orders.service';
import {Order} from '@app/_models';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html'
})
export class OrdersComponent implements OnInit {
  loading: boolean;
  token: string;
  orders: Order[];
  constructor(private authService: AuthenticationService,
              private ordersService: OrdersService) { }

  ngOnInit(): void {
    this.token = this.authService.tokenValue;
  }

}
