import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';

import { MapaPage } from './mapa';
import { MapaPageRoutingModule } from './mapa-routing.module';

@NgModule({
  imports: [
    CommonModule,
    IonicModule,
    MapaPageRoutingModule
  ],
  declarations: [
    MapaPage,
  ]
})
export class MapaModule { }