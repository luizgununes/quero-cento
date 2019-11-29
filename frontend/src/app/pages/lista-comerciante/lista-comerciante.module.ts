import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';

import { TelaListaComerciante } from './lista-comerciante';
import { TelaListaComercianteRoutingModule } from './lista-comerciante-routing.module';

@NgModule({
  imports: [
    CommonModule,
    IonicModule,
    TelaListaComercianteRoutingModule
  ],
  declarations: [TelaListaComerciante],
})
export class ListaComercianteModule { }