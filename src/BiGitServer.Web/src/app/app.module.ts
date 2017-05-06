import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';

import { AlertComponent } from './_directives/index';
import { AuthGuard } from './_guards/index';
import { AlertService, AuthenticationService, UserService } from './_services/index';
import { HomeComponent } from './home/index';
import { LoginComponent } from './login/login.component';
import {RegisterComponent} from './register/register.component';
// used to create fake backend
import { fakeBackendProvider } from './_helpers/index';
import { MockBackend, MockConnection } from '@angular/http/testing';
import { BaseRequestOptions } from '@angular/http';


import {routing} from './app.routing';
// const userRoutes: Routes = [
//  { path: '', redirectTo: '/userlist', pathMatch: 'full' },
//    { path: 'userlist',  component: UserListComponent },
//   { path: 'post/:id', component: UserPostComponent }
// ];
@NgModule({
  declarations: [
    AppComponent,AlertComponent,
        HomeComponent,
        LoginComponent,
        RegisterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing
   // RouterModule.forRoot(userRoutes)
  ],
  //exports:[Comp1],
  providers: [
        AuthGuard,
        AlertService,
        AuthenticationService,
        UserService,

        // providers used to create fake backend
        fakeBackendProvider,
        MockBackend,
        BaseRequestOptions
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
