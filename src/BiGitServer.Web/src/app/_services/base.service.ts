import { Http, Headers, RequestOptions, Response,URLSearchParams } from '@angular/http';
export class BaseService{
    getRequestOpt():RequestOptions{
        let currentUser = JSON.parse(sessionStorage.getItem('currentUser'));
        let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.token,'Content-Type': 'application/json' });
        let ro = new RequestOptions({headers:headers});
        
        return ro;
    }

}