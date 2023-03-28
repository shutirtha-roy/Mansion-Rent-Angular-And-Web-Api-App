import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { AuthComponent } from './auth/auth.component';
import { MansionComponent } from './mansion/mansion.component';
import { MansionNumberComponent } from './mansion-number/mansion-number.component';


@NgModule({
  declarations: [
    AuthComponent,
    MansionComponent,
    MansionNumberComponent
  ],
  imports: [
    CommonModule,
    PagesRoutingModule
  ]
})
export class PagesModule { }
