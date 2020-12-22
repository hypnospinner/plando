import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';

import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { HomeComponent } from './home';
import { AdminComponent } from './admin';
import { LoginComponent } from './login';
import { RegisterComponent } from './register';
import { AdminServicesComponent } from './admin-services';

import { AdminLaundriesComponent } from './admin-laundries';
import { LaundryRegistrationComponent } from './laundry-registration';
import { AdminLaundryComponent } from './admin-laundry/admin-laundry.component';
import { HeaderComponent } from './header/header.component';
import { OrdersComponent } from './orders/orders.component';
import { ManagerRegistrationComponent } from './manager-registration/manager-registration.component';
import { OrderComponent } from './order/order.component';
import { ManagerBindingComponent } from './manager-binding/manager-binding.component';

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        FormsModule,
        HttpClientModule,
        AppRoutingModule
    ],
    declarations: [
        HeaderComponent,
        AppComponent,
        HomeComponent,
        AdminComponent,
        LoginComponent,
        RegisterComponent ,
        AdminServicesComponent ,
        AdminLaundriesComponent ,
        LaundryRegistrationComponent ,
        AdminLaundryComponent,
        OrdersComponent,
        ManagerRegistrationComponent,
        OrderComponent,
        ManagerBindingComponent
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
