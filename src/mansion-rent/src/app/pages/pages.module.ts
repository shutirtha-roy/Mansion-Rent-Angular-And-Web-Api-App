import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { PagesRoutingModule } from './pages-routing.module';
import { AuthComponent } from './auth/auth.component';
import { MansionListComponent } from './mansion/mansion-list/mansion-list.component';
import { AddMansionComponent } from './mansion/add-mansion/add-mansion.component';
import { EditMansionComponent } from './mansion/edit-mansion/edit-mansion.component';
import { DeleteMansionComponent } from './mansion/delete-mansion/delete-mansion.component';
import { HomeComponent } from './home/home.component';


@NgModule({
  declarations: [
    AuthComponent,
    MansionListComponent,
    MansionListComponent,
    AddMansionComponent,
    EditMansionComponent,
    DeleteMansionComponent,
    HomeComponent
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    FormsModule
  ]
})
export class PagesModule { }
