import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ListaComerciantePage } from './lista-comerciante';
const routes: Routes = [
  {
    path: '',
    component: ListaComerciantePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ListaComerciantePageRoutingModule {}