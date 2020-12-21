import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home';
import { AdminComponent } from './admin';
import { LoginComponent } from './login';
import { RegisterComponent } from './register';
import { AuthGuard } from './_helpers';
import { Role } from './_models';
import {AdminServicesComponent} from './admin-services';
import {AdminLaundriesComponent} from './admin-laundries';
import {AdminLaundryComponent} from '@app/admin-laundry/admin-laundry.component';
import {LaundryRegistrationComponent} from './laundry-registration';
import {OrdersComponent} from '@app/orders';
import {ManagerRegistrationComponent} from '@app/manager-registration';
import {OrderComponent} from '@app/order';


const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'orders',
        component: OrdersComponent,
        canActivate: [AuthGuard],
    },
    {
        path: 'orders/:id',
        component: OrderComponent,
        canActivate: [AuthGuard],
    },
    {
        path: 'admin',
        component: AdminComponent,
        canActivate: [AuthGuard],
        data: { roles: [Role.Administrator] }
    },
    {
      path: 'admin/laundries',
      component: AdminLaundriesComponent,
      canActivate: [AuthGuard],
      data: { roles: [Role.Administrator]}
    },
    {
      path: 'admin/laundries/:id',
      component: AdminLaundryComponent,
      canActivate: [AuthGuard],
      data: { roles: [Role.Administrator]}
    },
    {
      path: 'admin/services',
      component: AdminServicesComponent,
      canActivate: [AuthGuard],
      data: { roles: [Role.Administrator]}
    },
    {
      path: 'register/laundry',
      component: LaundryRegistrationComponent,
      canActivate: [AuthGuard],
      data: { roles: [Role.Administrator]}
    },
    {
      path: 'register/manager',
      component: ManagerRegistrationComponent,
      canActivate: [AuthGuard],
      data: { roles: [Role.Administrator]}
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'register',
        component: RegisterComponent
    },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
