import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DetalheComerciantePage } from './detalhe-comerciante';

const routes: Routes = [
  {
    path: '',
    component: DetalheComerciantePage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DetalheComerciantePageRoutingModule { }