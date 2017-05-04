import { Component,OnInit } from '@angular/core';
import { Http,RequestOptions,Headers } from '@angular/http';
import 'rxjs/add/operator/map'
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit{
    title = 'app works!';
    people: DataModel;
  constructor(private http:Http){

  }
   ngOnInit(){
    // let headers = new Headers({ 'Access-Control-Allow-Origin': '*' });
    // let options = new RequestOptions({ headers: headers, withCredentials: true});
    console.log("nerede");
    this.http.get("/home/fakedata", { headers: new Headers({'Accept' : '*/*' }) })
 // Call map on the response observable to get the parsed people object
      .map(res => res.json())
      // Subscribe to the observable to get the parsed people object and attach it to the
        // component
        .subscribe(people => this.people = people as DataModel);
  }
  showMessage() {
       console.log("show message");
       window.alert("mesaj");
   }
}

interface DataModel {
    id: number;
    name: string;
    havePicture:boolean;
}
