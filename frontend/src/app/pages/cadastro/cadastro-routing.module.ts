import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TelaCadastro } from './cadastro';

const routes: Routes = [
  {
    path: '',
    component: TelaCadastro
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TelaCadastroRoutingModule { }