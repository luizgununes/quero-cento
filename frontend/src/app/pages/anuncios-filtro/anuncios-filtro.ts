import { AfterViewInit, Component } from '@angular/core';
import { Config, ModalController, NavParams } from '@ionic/angular';
import { ConferenceData } from '../../providers/conference-data';

@Component({
  selector: 'tela-anuncios-filtro',
  templateUrl: 'anuncios-filtro.html',
  styleUrls: ['./anuncios-filtro.scss'],
})
export class TelaAnunciosFiltro implements AfterViewInit {
  ios: boolean;

  tracks: {name: string, icon: string, isChecked: boolean}[] = [];

  constructor(
    public confData: ConferenceData,
    private config: Config,
    public modalCtrl: ModalController,
    public navParams: NavParams
  ) { }

  ionViewWillEnter() {
    this.ios = this.config.get('mode') === `ios`;
  }

  ngAfterViewInit() {

    const excludedTrackNames = this.navParams.get('excludedTracks');

    this.confData.getTracks().subscribe((tracks: any[]) => {
      tracks.forEach(track => {
        this.tracks.push({
          name: track.nome,
          icon: track.icon,
          isChecked: (excludedTrackNames.indexOf(track.name) === -1)
        });
      });
    });
  }

  selectAll(check: boolean) {
    this.tracks.forEach(track => {
      track.isChecked = check;
    });
  }

  aplicarFiltro() {
    const excludedTrackNames = this.tracks.filter(c => !c.isChecked).map(c => c.name);
    this.dismiss(excludedTrackNames);
  }

  dismiss(data?: any) {
    this.modalCtrl.dismiss(data);
  }
}