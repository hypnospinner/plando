import {Component, OnInit} from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '@app/_models';
import {UserService, AuthenticationService, ProfileService} from '@app/_services';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent implements OnInit {
    loading = false;
    user: User;

    constructor(
        private profileService: ProfileService,
        private authenticationService: AuthenticationService
    ) { }

    ngOnInit() {
        this.loading = true;
        this.profileService.getProfile().pipe(first()).subscribe(user => {
            this.loading = false;
            this.user = user;
        });
    }
}
