import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../guards/auth.guard';
import { MansionNumberListComponent } from './mansion-number/mansion-number-list/mansion-number-list.component';
import { MansionListComponent } from './mansion/mansion-list/mansion-list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'auth/login',
    pathMatch: 'full',
  },
  {
    path: '',
    children: [
      {
        path: 'auth',
        loadChildren: () =>
          import('./auth/auth.module').then((m) => m.AuthModule),
      },
      {
        path: 'mansion',
        component: MansionListComponent, 
        canActivate: [AuthGuard]
      },
      {
        path: 'mansion-number',
        component: MansionNumberListComponent, 
        canActivate: [AuthGuard]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
