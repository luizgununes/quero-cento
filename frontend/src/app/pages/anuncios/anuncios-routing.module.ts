import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TelaAnuncios } from './anuncios';

const routes: Routes = [
  {
    path: '',
    component: TelaAnuncios
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TelaAnunciosRoutingModule { }