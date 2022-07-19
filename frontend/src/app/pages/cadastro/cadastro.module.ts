import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { TelaCadastro } from './cadastro';
import { TelaCadastroRoutingModule } from './cadastro-routing.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TelaCadastroRoutingModule
  ],
  declarations: [
    TelaCadastro,
  ]
})

export class CadastroModule { }