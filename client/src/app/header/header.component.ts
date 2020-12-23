import { Component, OnInit } from '@angular/core';
import {Subscription} from 'rxjs';
import {AuthenticationService, ProfileService} from '@app/_services';
import {Role, User} from '@app/_models';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent implements OnInit {
  token: string;
  role: string;
  constructor(public authenticationService: AuthenticationService) { }

  ngOnInit(): void {
    this.authenticationService.token.subscribe(x => {
      const jwt = new JwtHelperService();
      this.token = x;
      if (x) {
        this.role = jwt.decodeToken(x)['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'].toLowerCase();
      }
    });
  }

  get isAdmin() {
    return this.token && this.role === Role.Administrator;
  }

  get isManager() {
    return this.token && this.role === Role.Manager;
  }

  logout() {
    this.authenticationService.logout();
  }
}
