import { NgModule } from '@angular/core';
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { GraphsComponent } from './graphs/graphs.component';
import { ChartsModule } from 'ng2-charts';
import {ButtonModule} from 'primeng/button';
import { MonthWiseChartsComponent } from './graphs/month-wise-charts/month-wise-charts.component';
import { CategoryWiseChartsComponent } from './graphs/category-wise-charts/category-wise-charts.component';

@NgModule({
  imports: [FormsModule,RouterModule,CommonModule,ReactiveFormsModule,ButtonModule,ChartsModule],
  exports: [UserDashboardComponent,
    AdminDashboardComponent],
  declarations: [
    UserDashboardComponent,
    AdminDashboardComponent,
    GraphsComponent,
    MonthWiseChartsComponent,
    CategoryWiseChartsComponent
  ],
  providers: [],
})
export class DashboardModule { }
