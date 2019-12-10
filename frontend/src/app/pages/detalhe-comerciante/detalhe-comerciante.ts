import { Component, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConferenceData } from '../../providers/conference-data';

@Component({
  selector: 'tela-detalhe-comerciante',
  templateUrl: 'detalhe-comerciante.html',
  styleUrls: ['./detalhe-comerciante.scss'],
})
export class TelaDetalheComerciante {
  comerciante: any;

  constructor(
    private dataProvider: ConferenceData,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ionViewWillEnter() {
    this.dataProvider.load().subscribe((data: any) => {
      const comercianteId = this.route.snapshot.paramMap.get('comercianteId');
      if (data && data.comerciantes) {
        for (const comerciante of data.comerciantes) {
          if (comerciante && comerciante.id === comercianteId) {
            this.comerciante = comerciante;
            break;
          }
        }
      }
    });
  }
}