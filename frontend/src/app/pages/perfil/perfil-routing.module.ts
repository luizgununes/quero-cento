import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TelaPerfil } from './perfil';

const routes: Routes = [
  {
    path: '',
    component: TelaPerfil
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TelaPerfilRoutingModule { }