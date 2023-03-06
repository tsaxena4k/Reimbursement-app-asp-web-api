import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';


@NgModule({
    imports: [FormsModule,RouterModule],
    exports: [LoginComponent,SignupComponent],
    declarations: [LoginComponent,SignupComponent],
    providers: [],
})
export class HomeModule { }
