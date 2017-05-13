import { Component, OnInit,Input } from '@angular/core';
import {Router }from '@angular/router';
import {AuthenticationService}from'../_services/authentication.service';
@Component({   
    moduleId: module.id,
    selector: 'top-nav',
    templateUrl: './top-nav.component.html',
    styleUrls: ['top-nav.component.css']
})
export class TopNavComponent implements OnInit {
    isAuthrized:boolean=true;
    constructor(private route:Router,private auth:AuthenticationService ) {     
    }

    ngOnInit() { 
        this.isLoggedIn();
    }
    isLoggedIn():void{
        console.log("top nav isLoggedIn");        
        //return this.auth.getLoginStatus();
        if (localStorage.getItem('currentUser')) {
            // logged in so return true           
            //return true;
            console.log("true");
            this.isAuthrized=true;
        }else{
            //return false;
            console.log("false");
            this.isAuthrized=false;
        }
    }
}