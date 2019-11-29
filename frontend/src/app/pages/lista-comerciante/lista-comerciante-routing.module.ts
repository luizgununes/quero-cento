import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TelaListaComerciante } from './lista-comerciante';
const routes: Routes = [
  {
    path: '',
    component: TelaListaComerciante
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TelaListaComercianteRoutingModule {}