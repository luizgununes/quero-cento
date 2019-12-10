import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { TelaAbas } from './tela-abas';
import { TelaAbasRoutingModule } from './tela-abas-routing.module';
import { MapaModule } from '../mapa/mapa.module';
import { AnunciosModule } from '../anuncios/anuncios.module';
import { DetalheAnuncioModule } from '../anuncio-detalhe/anuncio-detalhe.module';
import { DetalheComercianteModule } from '../detalhe-comerciante/detalhe-comerciante.module';
import { ListaComercianteModule } from '../lista-comerciante/lista-comerciante.module';

@NgModule({
  imports: [
    CommonModule,
    IonicModule,
    MapaModule,
    AnunciosModule,
    DetalheAnuncioModule,
    DetalheComercianteModule,
    ListaComercianteModule,
    TelaAbasRoutingModule
  ],
  declarations: [
    TelaAbas
  ]
})
export class AbasModule { }