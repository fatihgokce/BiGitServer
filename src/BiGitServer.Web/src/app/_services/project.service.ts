import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response,URLSearchParams } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import {BaseService} from './base.service';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import {Project} from '../_models/project';
@Injectable()
export class ProjectService extends BaseService {
    constructor(private http:Http){
        super();
    }
    getAll():Observable<Project[]>{
        let ro=this.getRequestOpt();
        return this.http.get('/api/project',ro).map((res:Response)=>res.json());
    }
    create(project:Project){
        let requestOption=this.getRequestOpt();
        return this.http.post('/api/project',project,requestOption)
               .map((response:Response)=>response.json());
    }

}