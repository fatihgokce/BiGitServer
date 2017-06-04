import { Component, OnInit,Input } from '@angular/core';
import {Router }from '@angular/router';
import {AuthenticationService}from'../_services/authentication.service';
import {BaseComponent} from '../_shared/index';
@Component({   
    moduleId: module.id,
    selector: 'top-nav',
    templateUrl: './top-nav.component.html',
    styleUrls: ['top-nav.component.css']
})
export class TopNavComponent extends BaseComponent implements OnInit {
    isAuthrized:boolean=true; 
    constructor(private router: Router,private auth:AuthenticationService ) {
      super();
    }
    ngOnInit() { 
        console.log("top nav ngoninit");       
    }
    
}