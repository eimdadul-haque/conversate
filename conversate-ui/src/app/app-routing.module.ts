import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path:'auth',
    loadChildren: () => import('./account/account.module').then(m => m.AccountModule)
  },
  {
    path:'page',
    loadChildren: () => import('./pages/pages.module').then(m => m.PagesModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
