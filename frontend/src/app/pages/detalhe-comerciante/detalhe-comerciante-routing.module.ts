import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TelaDetalheComerciante } from './detalhe-comerciante';

const routes: Routes = [
  {
    path: '',
    component: TelaDetalheComerciante
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TelaDetalheComercianteRoutingModule { }