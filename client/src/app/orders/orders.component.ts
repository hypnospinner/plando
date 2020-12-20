import { Component, OnInit } from '@angular/core';
import {AuthenticationService, LaundryService} from '@app/_services';
import {OrdersService} from '@app/_services/orders.service';
import {Laundry, Order} from '@app/_models';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {first} from 'rxjs/operators';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html'
})
export class OrdersComponent implements OnInit {
  loading: boolean;
  token: string;
  orders: Order[];
  createOrderForm: FormGroup;
  laundryControl;
  selectFormControl;
  laundries: Laundry[];
  selectedLaundry: Laundry;
  submitted = false;
  error = '';
  constructor(private authService: AuthenticationService,
              private laundryService: LaundryService,
              private ordersService: OrdersService,
              private formBuilder: FormBuilder,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    this.token = this.authService.tokenValue;
    this.laundryService.getAll().pipe(first())
      .subscribe(laundries => this.laundries = laundries);
    this.createOrderForm = this.formBuilder.group({
      title: ['', Validators.required],
    });
    this.laundryControl = new FormControl('', Validators.required);
    this.selectFormControl = new FormControl('', Validators.required);
  }
  get f() { return this.createOrderForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.createOrderForm.invalid) {
      return;
    }
    this.loading = true;
    this.ordersService.createOrder(this.f.title.value)
      .pipe(first())
      .subscribe({
        next: () => {
          this.submitted = true;
        },
        error: error => {
          this.error = error;
          this.loading = false;
        }
      });
  }
}
