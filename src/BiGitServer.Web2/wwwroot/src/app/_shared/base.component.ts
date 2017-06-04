import { Component } from '@angular/core';
import {AuthGuard} from '../_guards/index';
// @Component({  
//   //changeDetection: ChangeDetectionStrategy.OnPush 
// })
export class BaseComponent {
    isAuthrized:boolean;
    constructor() {     
    
    }

  
    public get isAuthenticated():boolean{
        //console.log("neden");
        //this.isLoggedIn();
        return AuthGuard.isAuthenticated; //this.isAuthrized;//AuthenticationService.userLoggedIn;
    }
 
}