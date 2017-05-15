import { AuthGuard } from '../_guards/index';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule }        from '@angular/forms';
import {UserListComponent} from './user-list.component';
import {UserCreateComponent} from './user-create.compontent';
import {UserService} from '../_services/user.service';
import { RouterModule, Routes } from '@angular/router';
export const userRoutes: Routes = [
  { path: 'users', component: UserListComponent,canActivate: [AuthGuard]  },
  { path:'create-user',component:UserCreateComponent}
];

@NgModule({
    declarations: [UserListComponent,UserCreateComponent],
    imports: [CommonModule,FormsModule,RouterModule.forChild(userRoutes) ],
    //exports: [BrowserModule],//if open get  Maximum call stack size exceeded
    providers: [UserService]
})
export class UserModule {}