import { Component, ViewChild, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertController, IonList, LoadingController, ModalController, ToastController, Config } from '@ionic/angular';
import { TelaAnunciosFiltro } from '../anuncios-filtro/anuncios-filtro';
import { ConferenceData } from '../../providers/conference-data';
import { UserData } from '../../providers/user-data';

@Component({
  selector: 'page-anuncios',
  templateUrl: 'anuncios.html',
  styleUrls: ['./anuncios.scss'],
})
export class TelaAnuncios implements OnInit {

  @ViewChild('listaAnuncios', { static: true }) listaAnuncios: IonList;

  ios: boolean;
  dayIndex = 0;
  queryText = '';
  segment = 'all';
  excludeTracks: any = [];
  anunciosMostrados: any = [];
  groups: any = [];
  confDate: string;

  constructor(
    public alertCtrl: AlertController,
    public confData: ConferenceData,
    public loadingCtrl: LoadingController,
    public modalCtrl: ModalController,
    public router: Router,
    public toastCtrl: ToastController,
    public user: UserData,
    public config: Config
  ) { }

  ngOnInit() {
    this.atualizarAnuncios();

    this.ios = this.config.get('mode') === 'ios';
  }

  atualizarAnuncios() {
    if (this.listaAnuncios) {
      this.listaAnuncios.closeSlidingItems();
    }

    this.confData.getTimeline(this.dayIndex, this.queryText, this.excludeTracks, this.segment).subscribe((data: any) => {
      this.anunciosMostrados = data.anunciosMostrados;
      this.groups = data.groups;
    });
  }

  async filtroSelecionado() {
    const modal = await this.modalCtrl.create({
      component: TelaAnunciosFiltro,
      componentProps: { excludedTracks: this.excludeTracks }
    });
    await modal.present();

    const { data } = await modal.onWillDismiss();
    if (data) {
      this.excludeTracks = data;
      this.atualizarAnuncios();
    }
  }
}