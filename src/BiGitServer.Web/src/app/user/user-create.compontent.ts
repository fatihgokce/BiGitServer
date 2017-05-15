import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {AlertService,UserService} from '../_services/index';
@Component({
    moduleId:module.id,
    templateUrl: './user-create.component.html',
    //styleUrls: ['./name.component.css']
})
export class UserCreateComponent implements OnInit {
    loading:boolean=false;
    powers = ['Really Smart', 'Super Flexible','Super Hot', 'Weather Changer'];
    model:any={};
    submitted = false;
    onSubmit() { 
        this.submitted = true;
        console.log("oleyy");        
     }
    constructor(
        private router:Router,
        private alertService:AlertService,
        private userService:UserService
    ) { }
   
    ngOnInit() { }
    saveUser(){
        this.loading=true;
    }
}