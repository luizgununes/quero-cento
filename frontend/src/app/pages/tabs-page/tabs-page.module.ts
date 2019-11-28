import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';

import { TabsPage } from './tabs-page';
import { TabsPageRoutingModule } from './tabs-page-routing.module';

import { SobreModule } from '../sobre/sobre.module';
import { MapaModule } from '../mapa/mapa.module';
import { ScheduleModule } from '../schedule/schedule.module';
import { SessionDetailModule } from '../session-detail/session-detail.module';
import { DetalheComercianteModule } from '../detalhe-comerciante/detalhe-comerciante.module';
import { ListaComercianteModule } from '../lista-comerciante/lista-comerciante.module';

@NgModule({
  imports: [
    SobreModule,
    CommonModule,
    IonicModule,
    MapaModule,
    ScheduleModule,
    SessionDetailModule,
    DetalheComercianteModule,
    ListaComercianteModule,
    TabsPageRoutingModule
  ],
  declarations: [
    TabsPage,
  ]
})
export class TabsModule { }