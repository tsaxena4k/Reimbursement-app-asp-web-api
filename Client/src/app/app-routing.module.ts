import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.gaurd';
import { AdminDashboardComponent } from './components/dashboard/admin-dashboard/admin-dashboard.component';
import { UserDashboardComponent } from './components/dashboard/user-dashboard/user-dashboard.component';
import { LoginComponent } from './components/home/login/login.component';
import { SignupComponent } from './components/home/signup/signup.component';
import { Role } from './models/Role/role';

const routes: Routes = [
  {path:'',component:LoginComponent, pathMatch: 'full' },
  {path:'signup',component:SignupComponent},
  {path:'userdashboard',component:UserDashboardComponent,canActivate:[AuthGuard],data:{roles:[Role.Basic]}},
  {path:'admindashboard',component:AdminDashboardComponent,canActivate:[AuthGuard],data:{roles:[Role.Admin]}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
