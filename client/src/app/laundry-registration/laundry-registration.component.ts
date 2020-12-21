import { Component, OnInit } from '@angular/core';
import {LaundryService} from '@app/_services';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {first} from 'rxjs/operators';

@Component({
  selector: 'app-laundry-registration',
  templateUrl: './laundry-registration.component.html'
})
export class LaundryRegistrationComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private laundryService: LaundryService
  ) {}

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      address: ['', Validators.required],
    });
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;
    this.laundryService.registerLaundry(this.f.address.value)
      .pipe(first())
      .subscribe({
        next: () => {
          // get return url from query parameters or default to home page
          this.loading = false;
          const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/admin/laundries';
          this.router.navigateByUrl(returnUrl);
        },
        error: error => {
          this.error = error;
          this.loading = false;
        }
      });
  }
}
