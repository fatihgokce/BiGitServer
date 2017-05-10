import { Injectable } from '@angular/core';
import { Http, Headers, Response,RequestOptions,URLSearchParams  } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthenticationService {
    static userLoggedIn : boolean = false;
    constructor(private http: Http) { 
        console.log("auth service create");
    }

    login(username: string, password: string) {
        let params: URLSearchParams = new URLSearchParams();
        params.set('username', username);
        params.set('password', password);

        let requestOptions = new RequestOptions();
        requestOptions.search = params;
        //{search:JSON.stringify({ username: username, password: password })}
        return this.http.get('/api/token',requestOptions)
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                let user = response.json();
                console.log(user.token);
                if (user && user.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(user));
                    AuthenticationService.userLoggedIn=true;
                }
            });
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
    }
    getLoginStatus():boolean{
        console.log(`logged ${AuthenticationService.userLoggedIn}`);
        return AuthenticationService.userLoggedIn;
    }
}