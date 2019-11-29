import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TelaDetalheAnuncio } from './anuncio-detalhe';

const routes: Routes = [
  {
    path: '',
    component: TelaDetalheAnuncio
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TelaDetalheAnuncioRoutingModule { }