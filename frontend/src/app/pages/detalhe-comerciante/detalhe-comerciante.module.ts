import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TelaDetalheComerciante } from './detalhe-comerciante';
import { TelaDetalheComercianteRoutingModule } from './detalhe-comerciante-routing.module';
import { IonicModule } from '@ionic/angular';

@NgModule({
  imports: [
    CommonModule,
    IonicModule,
    TelaDetalheComercianteRoutingModule
  ],
  declarations: [
    TelaDetalheComerciante,
  ]
})
export class DetalheComercianteModule { }