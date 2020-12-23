import { Component, OnInit } from '@angular/core';
import {ServiceService} from '@app/_services';
import {Service} from '@app/_models';

@Component({
  selector: 'app-admin-services',
  templateUrl: './admin-services.component.html'
})
export class AdminServicesComponent implements OnInit {
  services: Service[];
  errMess: string;
  loading = false;
  constructor(private serviceService: ServiceService) { }

  ngOnInit(): void {
    this.loading = true;
    this.serviceService.getAll()
      .subscribe(services => {
        this.services = services;
        this.loading = false;
      }, error => this.errMess = error);
  }

}
