import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { AuthComponent } from './auth/auth.component';
import { MansionListComponent } from './mansion/mansion-list/mansion-list.component';
import { MansionNumberListComponent } from './mansion-number/mansion-number-list/mansion-number-list.component';


@NgModule({
  declarations: [
    AuthComponent,
    MansionListComponent,
    MansionNumberListComponent,
    MansionListComponent,
    MansionNumberListComponent
  ],
  imports: [
    CommonModule,
    PagesRoutingModule
  ]
})
export class PagesModule { }
