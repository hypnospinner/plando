import { Component, OnInit } from '@angular/core';
import { LaundryService } from '@app/_services';
import {Laundry} from '@app/_models';

@Component({
  selector: 'app-admin-laundry',
  templateUrl: './admin-laundry.component.html'
})
export class AdminLaundryComponent implements OnInit {
  laundry: Laundry;
  constructor(private laundryService: LaundryService) { }

  ngOnInit(): void {
  }

}
