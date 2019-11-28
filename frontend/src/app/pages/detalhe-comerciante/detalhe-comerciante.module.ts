import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DetalheComerciantePage } from './detalhe-comerciante';
import { DetalheComerciantePageRoutingModule } from './detalhe-comerciante-routing.module';
import { IonicModule } from '@ionic/angular';

@NgModule({
  imports: [
    CommonModule,
    IonicModule,
    DetalheComerciantePageRoutingModule
  ],
  declarations: [
    DetalheComerciantePage,
  ]
})
export class DetalheComercianteModule { }