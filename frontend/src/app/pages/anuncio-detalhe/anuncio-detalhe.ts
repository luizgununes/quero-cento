import { Component } from '@angular/core';
import { ConferenceData } from '../../providers/conference-data';
import { ActivatedRoute } from '@angular/router';
import { UserData } from '../../providers/user-data';

@Component({
  selector: 'tela-anuncio-detalhe',
  styleUrls: ['./anuncio-detalhe.scss'],
  templateUrl: 'anuncio-detalhe.html'
})
export class TelaDetalheAnuncio {
  anuncio: any;
  isFavorite = false;
  defaultHref = '';

  constructor(
    private dataProvider: ConferenceData,
    private userProvider: UserData,
    private route: ActivatedRoute
  ) { }

  ionViewWillEnter() {
    this.dataProvider.load().subscribe((data: any) => {
      if (data && data.anuncios && data.anuncios[0] && data.anuncios[0].groups) {
        const anuncioId = this.route.snapshot.paramMap.get('anuncioId');
        for (const group of data.anuncios[0].groups) {
          if (group && group.anuncios) {
            for (const anuncio of group.anuncios) {
              if (anuncio && anuncio.id === anuncioId) {
                this.anuncio = anuncio;
                break;
              }
            }
          }
        }
      }
    });
  }

  ionViewDidEnter() {
    this.defaultHref = `/app/abas/anuncios`;
  }

  clicarAnuncio(item: string) {
    console.log('', item);
  }
}