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
import {LaundryRegistrationComponent} from './laundry-registration';

const routes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'admin',
        component: AdminComponent,
        canActivate: [AuthGuard],
        data: { roles: [Role.Admin] }
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: 'register',
        component: RegisterComponent
    },
    {
        path: 'admin/laundries',
        component: AdminLaundriesComponent,
        canActivate: [AuthGuard],
        data: { roles: [Role.Admin]}
    },
    {
        path: 'admin/services',
        component: AdminServicesComponent,
        canActivate: [AuthGuard],
        data: { roles: [Role.Admin]}
    },
    {
        path: 'register/laundry',
        component: LaundryRegistrationComponent,
        canActivate: [AuthGuard],
        data: { roles: [Role.Admin]}
    },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
