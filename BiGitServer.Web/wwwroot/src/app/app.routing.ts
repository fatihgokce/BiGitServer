import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/index';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './_guards/index';
import { RegisterComponent } from './register/register.component';
import {UserListComponent} from './user/user-list.component';
import {ProjectCreateComponent} from './project/index';
const appRoutes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },  
    //{ path: 'users', component: UserListComponent,canActivate: [AuthGuard] },
    {path:'create-project',component:ProjectCreateComponent,canActivate:[AuthGuard], data: { title: 'Create project' }},
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);