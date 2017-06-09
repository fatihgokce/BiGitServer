import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RemoteExistValidateDirective,HighlightDirective } from '../_directives/index';
@NgModule({
    declarations: [RemoteExistValidateDirective,HighlightDirective],
    imports: [ CommonModule],
    exports: [ RemoteExistValidateDirective,HighlightDirective ],
    providers: [],
    bootstrap: []
})
export class SharedModule {}