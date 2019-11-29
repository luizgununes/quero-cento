import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserData } from './user-data';

@Injectable({
  providedIn: 'root'
})
export class ConferenceData {
  data: any;

  constructor(public http: HttpClient, public user: UserData) { }

  load(): any {
    if (this.data) {
      return of(this.data);
    } else {
      return this.http
        .get('assets/data/data.json')
        .pipe(map(this.processData, this));
    }
  }

  processData(data: any) {
    this.data = data;

    this.data.anuncios.forEach((day: any) => {
      day.groups.forEach((group: any) => {
        group.anuncios.forEach((anuncio: any) => {
          anuncio.comerciantes = [];
          if (anuncio.comerciante) {
            anuncio.comerciante.forEach((comercianteNome: any) => {
              const comerciante = this.data.comerciantes.find(
                (s: any) => s.nome === comercianteNome
              );
              if (comerciante) {
                anuncio.comerciantes.push(comerciante);
                comerciante.anuncios = comerciante.anuncios || [];
                comerciante.anuncios.push(anuncio);
              }
            });
          }
        });
      });
    });

    return this.data;
  }

  getTimeline(
    dayIndex: number,
    queryText = '',
    excludeTracks: any[] = [],
    segment = 'all'
  ) {
    return this.load().pipe(
      map((data: any) => {
        const day = data.anuncios[dayIndex];
        day.anunciosMostrados = 0;

        queryText = queryText.toLowerCase().replace(/,|\.|-/g, ' ');
        const queryWords = queryText.split(' ').filter(w => !!w.trim().length);

        day.groups.forEach((group: any) => {
          group.hide = true;

          group.anuncios.forEach((anuncio: any) => {
            this.filtrarAnuncio(anuncio, queryWords, excludeTracks, segment);

            if (!anuncio.hide) {
              group.hide = false;
              day.anunciosMostrados++;
            }
          });
        });

        return day;
      })
    );
  }

  filtrarAnuncio(
    anuncio: any,
    queryWords: string[],
    excludeTracks: any[],
    segment: string
  ) {
    let matchesQueryText = false;
    if (queryWords.length) {
      queryWords.forEach((queryWord: string) => {
        if (anuncio.nome.toLowerCase().indexOf(queryWord) > -1) {
          matchesQueryText = true;
        }
      });
    } else {
      matchesQueryText = true;
    }

    let matchesTracks = false;
    anuncio.tracks.forEach((trackNome: string) => {
      if (excludeTracks.indexOf(trackNome) === -1) {
        matchesTracks = true;
      }
    });

    let matchesSegment = true;

    anuncio.hide = !(matchesQueryText && matchesTracks && matchesSegment);
  }

  getComerciantes() {
    return this.load().pipe(
      map((data: any) => {
        return data.comerciantes.sort((a: any, b: any) => {
          const aNome = a.nome.split(' ').pop();
          const bNome = b.nome.split(' ').pop();
          return aNome.localeCompare(bNome);
        });
      })
    );
  }

  getTracks() {
    return this.load().pipe(
      map((data: any) => {
        return data.tracks.sort();
      })
    );
  }

  getMap() {
    return this.load().pipe(
      map((data: any) => {
        return data.map;
      })
    );
  }
}