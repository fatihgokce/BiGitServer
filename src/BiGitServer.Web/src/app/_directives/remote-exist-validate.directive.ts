import { Directive,forwardRef, Attribute , HostListener, Input,ElementRef} from '@angular/core';
import { AsyncValidator,Validator, AbstractControl, NG_VALIDATORS ,NG_ASYNC_VALIDATORS} from '@angular/forms';
import {UserService} from '../_services/index';
import { Observable } from 'rxjs/Observable';
@Directive({
    selector: '[validateExistColumn]',
    providers: [{provide: NG_ASYNC_VALIDATORS, useExisting: RemoteExistValidateDirective, multi: true }]   
})
export class RemoteExistValidateDirective implements Validator  {
    //constructor(@Attribute('validateExistColumn') public validateExistColumn: string) {}
    userExist:boolean;
    constructor(private userService:UserService){}
    @Input('validateExistColumn') columnName: string;
    @HostListener('mouseenter') onMouseEnter() {
        console.log(this.columnName);
    }
    validate(c: AbstractControl)
    //: Promise<{[key : string] : any}>
    //|Observable<{[key : string] : any}>  
    {
        // return new Observable(observer => {
        //     let v = c.value;

        //     if (v) {
        //         this.userService.controlExistUser(this.columnName, v)
        //             .subscribe((r) => {
        //                 this.userExist = r;
        //                 if (this.userExist) {
        //                     observer.next({
        //                         asyncInvalid: true
        //                     });
        //                 } else {
        //                     observer.next(null);
        //                 }
        //             });

        //     } else {
        //         observer.next(null);
        //     }
        // });
           return new Promise((resolve) => {
               let v = c.value;
               if(v){
                   this.userService.controlExistUser(this.columnName,v).subscribe((p)=>{
                       this.userExist=p;
                       if(p){
                           resolve({taken:true});
                       }else{
                           resolve(null);
                       }
                   });        
               }else{
                   resolve(null);
               }   
           });
        //    .then(r=>{
        //      console.log(r);
        //      return r;  
        //    });


    }

}


