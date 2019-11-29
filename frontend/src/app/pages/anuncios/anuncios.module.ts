import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TelaAnuncios } from './anuncios';
import { TelaAnunciosFiltro } from '../anuncios-filtro/anuncios-filtro';
import { TelaAnunciosRoutingModule } from './anuncios-routing.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TelaAnunciosRoutingModule
  ],
  declarations: [
    TelaAnuncios,
    TelaAnunciosFiltro
  ],
  entryComponents: [
    TelaAnunciosFiltro
  ]
})
export class AnunciosModule { }