import { Component, OnInit } from '@angular/core';
import {AuthenticationService, LaundryService, ProfileService} from '@app/_services';
import {OrdersService} from '@app/_services/orders.service';
import {Laundry, Order, User} from '@app/_models';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {first} from 'rxjs/operators';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html'
})
export class OrdersComponent implements OnInit {
  user: User;
  loading: boolean;
  token: string;
  orders: Order[];
  createOrderForm: FormGroup;
  selectedLaundry: Laundry;
  laundries: Laundry[];
  submitted = false;
  error = '';
  constructor(private authService: AuthenticationService,
              private laundryService: LaundryService,
              private ordersService: OrdersService,
              private formBuilder: FormBuilder,
              private profileService: ProfileService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    this.token = this.authService.tokenValue;
    this.profileService.getProfile().pipe(first()).subscribe(user => {
        this.loading = false;
        this.user = user;
      });
    this.ordersService.getOrders().pipe(first()).subscribe(orders => this.orders = orders);
    this.laundryService.getAll().pipe(first())
      .subscribe(laundries => this.laundries = laundries);
    this.createOrderForm = this.formBuilder.group({
      title: ['', Validators.required],
      laundrySelect: ['', Validators.required]
    });
  }
  get f() { return this.createOrderForm.controls; }

  onSelectedLaundryChanged(){
    this.selectedLaundry = this.f.laundrySelect.value;
  }
  onSubmit() {
    this.submitted = true;
    if (this.createOrderForm.invalid) {
      return;
    }
    this.loading = true;
    this.ordersService.createOrder(this.user.id, this.selectedLaundry.id, this.f.title.value)
      .pipe(first())
      .subscribe({
        next: () => {
          this.loading = false;
        },
        error: error => {
          this.error = error;
          this.loading = false;
        }
      });
  }
}
