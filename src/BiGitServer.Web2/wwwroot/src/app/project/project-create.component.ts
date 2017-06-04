import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {Project} from '../_models/project';
import {AlertService,ProjectService} from '../_services/index';
@Component({    
    templateUrl: './project-create.component.html',   
    providers:[ProjectService] 
})
export class ProjectCreateComponent implements OnInit {
    submitted=false;
    model:any={};
    constructor(private router:Router,private alertService:AlertService,private projectService:ProjectService) { }

    ngOnInit() { }
    
    onSubmit(){
        this.submitted=true;
        this.projectService.create(this.model).subscribe(
            data =>{
                this.alertService.success('Project created succesful',true);
                this.router.navigate(['']);
            },
            error=>{
                this.alertService.error(error);
                this.submitted=false;

            }
        )
    }
}