import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

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

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
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
        AdminLaundryComponent],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
