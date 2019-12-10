import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TelaDetalheAnuncio } from './anuncio-detalhe';
import { TelaDetalheAnuncioRoutingModule } from './anuncio-detalhe-routing.module';
import { IonicModule } from '@ionic/angular';

@NgModule({
  imports: [
    CommonModule,
    IonicModule,
    TelaDetalheAnuncioRoutingModule
  ],
  declarations: [
    TelaDetalheAnuncio,
  ]
})
export class DetalheAnuncioModule { }
