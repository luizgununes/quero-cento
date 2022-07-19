import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

import { TelaLogin } from './login';
import { TelaLoginRoutingModule } from './login-routing.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    TelaLoginRoutingModule
  ],
  declarations: [
    TelaLogin,
  ]
})
export class LoginModule { }
