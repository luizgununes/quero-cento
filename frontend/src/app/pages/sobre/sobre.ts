import { Component, ViewEncapsulation } from '@angular/core';

import { PopoverController } from '@ionic/angular';

import { PopoverPage } from '../sobre-popover/sobre-popover';

@Component({
  selector: 'page-sobre',
  templateUrl: 'sobre.html',
  styleUrls: ['./sobre.scss'],
})
export class SobrePage {
  conferenceDate = '2047-05-17';

  constructor(public popoverCtrl: PopoverController) { }

  async presentPopover(event: Event) {
    const popover = await this.popoverCtrl.create({
      component: PopoverPage,
      event
    });
    await popover.present();
  }
}