import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';

import { SobrePage } from './sobre';
import { PopoverPage } from '../sobre-popover/sobre-popover';
import { SobrePageRoutingModule } from './sobre-routing.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SobrePageRoutingModule
  ],
  declarations: [SobrePage, PopoverPage],
  entryComponents: [PopoverPage],
  bootstrap: [SobrePage],
})
export class SobreModule { }