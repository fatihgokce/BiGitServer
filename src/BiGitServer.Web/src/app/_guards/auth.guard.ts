import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        //console.log(localStorage.getItem('currentUser'));
        if (localStorage.getItem('currentUser')) {
            var currentUser= JSON.parse(localStorage.getItem('currentUser'));
            let expireTime=new Date(currentUser.expireTime).getTime();
            let currentTime=new Date().getTime();
            console.log(`expire time:${expireTime} currentTime:${currentTime}`);
            if(expireTime>currentTime){
                return true;
            }else{
                this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
                return false;
            }
           
        }

        // not logged in so redirect to login page with the return url
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
        return false;
    }
}