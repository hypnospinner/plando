import { Component, OnInit } from '@angular/core';
import { Laundry } from '@app/_models';
import { LaundryService } from '@app/_services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-admin-laundries',
  templateUrl: './admin-laundries.component.html'
})
export class AdminLaundriesComponent implements OnInit {
  loading = false;
  laundries: Laundry[] = [];

  constructor(private laundryService: LaundryService) { }

  ngOnInit() {
    this.loading = true;
    this.laundryService.getAll().pipe(first()).subscribe(laundries => {
      this.loading = false;
      this.laundries = laundries;
    });
  }
}
