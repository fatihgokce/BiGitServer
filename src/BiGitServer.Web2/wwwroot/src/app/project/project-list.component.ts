import { Component, OnInit } from '@angular/core';
import {ProjectService,AlertService} from '../_services/index';
import {Project} from '../_models/project';
@Component({
    selector: 'project-list',
    templateUrl: './project-list.component.html',
    //styleUrls: ['./name.component.css']
    providers:[ProjectService]
})
export class ProjectListComponent implements OnInit {
    projects:Project[];
    constructor(private projectService:ProjectService,private alertService:AlertService) { }
   
    ngOnInit() { 
        this.loadAllProject();
    }
    private loadAllProject(){
        this.projectService.getAll().subscribe(data=>{
            this.projects=data;
        },error=>{
            this.alertService.error(error._body);
        });
    }
}