import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {
     static isAuthenticated:boolean;
    constructor(private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        //console.log(localStorage.getItem('currentUser'));
        if (localStorage.getItem('currentUser')) {
            var currentUser= JSON.parse(localStorage.getItem('currentUser'));
            let expireTime=new Date(currentUser.data.expiresIn).getTime();
            let currentTime=new Date().getTime();
            console.log(`expire time:${expireTime} currentTime:${currentTime}`);
        
            if(expireTime>currentTime){
                AuthGuard.isAuthenticated=true;
                return true;
            }else{
                AuthGuard.isAuthenticated=false;
                this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
                
                return false;
            }
           
        }
        // not logged in so redirect to login page with the return url
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
        return false;
    }
   
}