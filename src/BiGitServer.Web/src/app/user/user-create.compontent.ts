import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {AlertService,UserService} from '../_services/index';
@Component({
    moduleId:module.id,
    templateUrl: './user-create.component.html',
    //styleUrls: ['./name.component.css']
    
})
export class UserCreateComponent implements OnInit {
    loading: boolean = false;
    powers = ['Really Smart', 'Super Flexible', 'Super Hot', 'Weather Changer'];
    model: any = {};
    submitted = false;

    constructor(
        private router: Router,
        private alertService: AlertService,
        private userService: UserService
    ) {}

    ngOnInit() {}
    onSubmit() {
        this.submitted = true;
        console.log("oleyy");
        this.loading = true;
        this.userService.create(this.model)
            .subscribe(
                data => {
                    this.alertService.success('User created successful', true);
                    this.router.navigate(['/users']);
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
    }
    saveUser() {
        this.loading = true;
    }
}