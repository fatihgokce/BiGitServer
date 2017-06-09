import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response,URLSearchParams } from '@angular/http';

import { User } from '../_models/index';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import {BaseService} from './base.service';
@Injectable()
export class UserService extends BaseService  {
    constructor(private http: Http) { 
        super();
    }
    // private getRequestOpt():RequestOptions{
    //     let currentUser = JSON.parse(localStorage.getItem('currentUser'));
    //     let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.token,'Content-Type': 'application/json' });
      
    //     let ro = new RequestOptions({headers:headers});
        
    //     return ro;
    // }
    getAll():Observable<User[]> {
        let ro=super.getRequestOpt();
        return this.http.get('/api/user/',ro ).map((res:Response) => res.json());
    }
    controlExistUser(columnName:string,value:string):Observable<boolean>{
      
        let params: URLSearchParams = new URLSearchParams();
        params.set('columnName', columnName);    
        params.set('value', value);    
        // let currentUser = JSON.parse(localStorage.getItem('currentUser'));
        // let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.token });
        // let ro = new RequestOptions({headers:headers});
        let ro=super.getRequestOpt();
        //requestOptions.search = params;
        ro.search=params;
        //ro.headers=headers;
        console.log(ro.headers);
        return this.http.get('/api/user/ExistUser',ro ).map((res:Response) => res.json());
    }
    getById(id: number) {
        return this.http.get('/api/users/' + id, this.jwt()).map((response: Response) => response.json());
    }

    create(user: User) {
        // let params: URLSearchParams = new URLSearchParams();
        // params.set('value', user.username); 
        let ro=this.getRequestOpt();
        //ro.params=params;
        return this.http.post('/api/user', user, ro).map((response: Response) => response.json());
    }

    update(user: User) {
        return this.http.put('/api/users/' + user.Id, user, this.jwt()).map((response: Response) => response.json());
    }

    delete(id: number) {
        return this.http.delete('/api/users/' + id, this.jwt()).map((response: Response) => response.json());
    }

    // private helper methods

    private jwt() {
        // create authorization header with jwt token
        let currentUser = JSON.parse(sessionStorage.getItem('currentUser'));
        if (currentUser && currentUser.token) {
            let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.token });
            return new RequestOptions({ headers: headers });
        }
    }
}