import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { InAppBrowser } from '@ionic-native/in-app-browser/ngx';
import { ActionSheetController } from '@ionic/angular';

import { ConferenceData } from '../../providers/conference-data';

@Component({
  selector: 'page-lista-comerciante',
  templateUrl: 'lista-comerciante.html',
  styleUrls: ['./lista-comerciante.scss'],
})
export class ListaComerciantePage {
  comerciantes: any[] = [];

  constructor(
    public actionSheetCtrl: ActionSheetController,
    public confData: ConferenceData,
    public inAppBrowser: InAppBrowser,
    public router: Router
  ) { }

  ionViewDidEnter() {
    this.confData.getComerciantes().subscribe((comerciantes: any[]) => {
      this.comerciantes = comerciantes;
    });
  }

  async openContact(comerciante: any) {
    const mode = 'ios';

    const actionSheet = await this.actionSheetCtrl.create({
      header: 'Ligar para ' + comerciante.nome,
      buttons: [
        {
          text: `Ligar para ( ${comerciante.phone} )`,
          icon: mode !== 'ios' ? 'call' : null,
          handler: () => {
            window.open('tel:' + comerciante.phone);
          }
        }
      ]
    });

    await actionSheet.present();
  }
}