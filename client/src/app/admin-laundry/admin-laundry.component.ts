import { Component, OnInit } from '@angular/core';
import { LaundryService } from '@app/_services';
import {Laundry} from '@app/_models';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {switchMap} from 'rxjs/operators';

@Component({
  selector: 'app-admin-laundry',
  templateUrl: './admin-laundry.component.html'
})
export class AdminLaundryComponent implements OnInit {
  loading = false;
  errMess: string;
  laundry: Laundry;
  constructor(private laundryService: LaundryService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
      this.loading = true;
      this.route.params.pipe(switchMap((params: Params) => this.laundryService.getLaundry(params['id']) ))
        .subscribe(laundry => {
            this.laundry = laundry;
            this.loading = false;
          },
          errmess => this.errMess = (errmess as any));
  }
  deleteThisLaundry() {
      this.laundryService.deleteLaundry(this.laundry.id)
        .subscribe(resp => {
          const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/admin/laundries';
          this.router.navigateByUrl(returnUrl);
        })
  }
}
