import { Component, OnInit } from '@angular/core';
import {ServiceService} from '@app/_services';
import {Service} from '@app/_models';
import {first} from 'rxjs/operators';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-admin-services',
  templateUrl: './admin-services.component.html'
})
export class AdminServicesComponent implements OnInit {
  services: Service[];
  serviceForAdd: Service;
  errMess: string;
  createServiceForm: FormGroup;
  loading = false;
  submitted = false;
  constructor(private serviceService: ServiceService,
              private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.loading = true;
    this.serviceService.getAll()
      .subscribe(services => {
        this.services = services;
        this.loading = false;
      }, error => this.errMess = error);
    this.createServiceForm = this.formBuilder.group({
      title: ['', Validators.required],
      price: [0, Validators.required]
    });
  }
  get f() { return this.createServiceForm.controls; }
  onSubmit(){
    this.submitted = true;
    if (this.createServiceForm.invalid) {
      return;
    }

    this.loading = true;
    this.serviceService.addService(this.f.title.value, this.f.price.value)
      .pipe(first())
      .subscribe({
        next: () => {
          // get return url from query parameters or default to home page
          this.loading = false;
          // window.location.reload();
        },
        error: error => {
          this.errMess = error;
          this.loading = false;
        }
      });
  }
}
