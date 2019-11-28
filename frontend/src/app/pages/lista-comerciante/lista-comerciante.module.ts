import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';

import { ListaComerciantePage } from './lista-comerciante';
import { ListaComerciantePageRoutingModule } from './lista-comerciante-routing.module';

@NgModule({
  imports: [
    CommonModule,
    IonicModule,
    ListaComerciantePageRoutingModule
  ],
  declarations: [ListaComerciantePage],
})
export class ListaComercianteModule { }