import {
    Component,
    OnInit
} from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'authorized',
    templateUrl: './authorized.component.html',

})
export class AuthorizedComponent implements OnInit {
    isAuthrized:boolean;
    constructor() {}

    ngOnInit() {
     this.isLoggedIn();
    }
    get isAuth():boolean{
        return this.isAuthrized;//AuthenticationService.userLoggedIn;
    }
  
    isLoggedIn():void{
      if (localStorage.getItem('currentUser')) {
            var currentUser = JSON.parse(localStorage.getItem('currentUser'));
            let expireTime = new Date(currentUser.data.expiresIn).getTime();
            let currentTime = new Date().getTime();
            console.log(`expire time:${expireTime} currentTime:${currentTime}`);
            if (expireTime > currentTime) {
                this.isAuthrized= true;
            } else {               
                this.isAuthrized= false;
            }

        }else{
            this.isAuthrized=  false;
        }
    } 
}