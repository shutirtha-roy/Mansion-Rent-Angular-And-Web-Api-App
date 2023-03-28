import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { PagesRoutingModule } from './pages-routing.module';
import { AuthComponent } from './auth/auth.component';
import { MansionListComponent } from './mansion/mansion-list/mansion-list.component';
import { MansionNumberListComponent } from './mansion-number/mansion-number-list/mansion-number-list.component';
import { AddMansionComponent } from './mansion/add-mansion/add-mansion.component';
import { EditMansionComponent } from './mansion/edit-mansion/edit-mansion.component';


@NgModule({
  declarations: [
    AuthComponent,
    MansionListComponent,
    MansionNumberListComponent,
    MansionListComponent,
    MansionNumberListComponent,
    AddMansionComponent,
    EditMansionComponent
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    FormsModule
  ]
})
export class PagesModule { }
