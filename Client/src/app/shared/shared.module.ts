import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { RouterModule } from '@angular/router';
import { NotFoundComponent } from './components/404/404.component';


@NgModule({
    imports: [CommonModule,HttpClientModule,RouterModule],
    exports: [HeaderComponent,FooterComponent,CommonModule,FormsModule],
    declarations: [HeaderComponent,FooterComponent,NotFoundComponent],
    providers: [],
})
export class SharedModule { }
