import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../guards/auth.guard';
import { MansionNumberComponent } from './mansion-number/mansion-number.component';
import { MansionComponent } from './mansion/mansion.component';

const routes: Routes = [
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
        component: MansionComponent, 
        canActivate: [AuthGuard]
      },
      {
        path: 'mansion-number',
        component: MansionNumberComponent, 
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
