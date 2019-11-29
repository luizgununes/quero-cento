import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { InAppBrowser } from '@ionic-native/in-app-browser/ngx';
import { ActionSheetController } from '@ionic/angular';
import { ConferenceData } from '../../providers/conference-data';
import { CallNumber } from '@ionic-native/call-number/ngx';


@Component({
  selector: 'tela-lista-comerciante',
  templateUrl: 'lista-comerciante.html',
  styleUrls: ['./lista-comerciante.scss'],
})
export class TelaListaComerciante {
  comerciantes: any[] = [];

  constructor(
    public actionSheetCtrl: ActionSheetController,
    public confData: ConferenceData,
    public inAppBrowser: InAppBrowser,
    public router: Router,
    public callNumber: CallNumber
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
          text: `Ligar para ( ${comerciante.contato} )`,
          icon: mode !== 'ios' ? 'call' : 'call',
          handler: () => {
            this.callNumber.callNumber(comerciante.contato, true)
            .then(res => console.log('Launched dialer!', res))
            .catch(err => console.log('Error launching dialer', err));
          }
        }
      ]
    });

    await actionSheet.present();
  }
}