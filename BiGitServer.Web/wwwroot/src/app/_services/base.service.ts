import { Http, Headers, RequestOptions, Response,URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
export class BaseService{
    getRequestOpt():RequestOptions{
        let currentUser = JSON.parse(localStorage.getItem('currentUser'));
        let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.data.accessToken,'Content-Type': 'application/json' });
        let ro = new RequestOptions({headers:headers});
        
        return ro;
    }
    extractData(res: Response) {
      console.log(res);
      let body = res.text() ? res.json():{};
      return body;
    }

    handleError(error: Response | any) {
      // In a real world app, we might use a remote logging infrastructure
      let errMsg: string;
      if (error instanceof Response) {
          const body = error.json() || '';
          const err = body.error || JSON.stringify(body);
          errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
      } else {
          errMsg = error.message ? error.message : error.toString();
      }
      console.error(errMsg);
      return Observable.throw(errMsg);
    }

}