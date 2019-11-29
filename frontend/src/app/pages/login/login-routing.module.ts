import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TelaLogin } from './login';

const routes: Routes = [
  {
    path: '',
    component: TelaLogin
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TelaLoginRoutingModule { }
