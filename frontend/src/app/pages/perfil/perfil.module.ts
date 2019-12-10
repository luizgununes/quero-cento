import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';

import { TelaPerfil } from './perfil';
import { TelaPerfilRoutingModule } from './perfil-routing.module';

@NgModule({
  imports: [
    CommonModule,
    IonicModule,
    TelaPerfilRoutingModule
  ],
  declarations: [
    TelaPerfil,
  ]
})
export class PerfilModule { }