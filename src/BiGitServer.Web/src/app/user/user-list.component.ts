import { Component, OnInit } from '@angular/core';
import {UserService} from '../_services/index';
import{User} from '../_models/index';
@Component({   
    moduleId:module.id,
    templateUrl: './user-list.component.html',
    //styleUrls: ['./name.component.css']
})
export class UserListComponent implements OnInit {
    users:User[];
    constructor(private userService:UserService) { }

    ngOnInit() { 
        this.loadAllUsers();
    }
    private loadAllUsers() {
        this.userService.getAll().subscribe(users => { this.users = users; });
    }
}