import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TelaAbas } from './tela-abas';
import { TelaAnuncios } from '../anuncios/anuncios';


const routes: Routes = [
  {
    path: 'abas',
    component: TelaAbas,
    children: [
      {
        path: 'anuncios',
        children: [
          {
            path: '',
            component: TelaAnuncios,
          },
          {
            path: 'anuncio/:anuncioId',
            loadChildren: () => import('../anuncio-detalhe/anuncio-detalhe.module').then(m => m.DetalheAnuncioModule)
          }
        ]
      },
      {
        path: 'comerciantes',
        children: [
          {
            path: '',
            loadChildren: () => import('../lista-comerciante/lista-comerciante.module').then(m => m.ListaComercianteModule)
          },
          {
            path: 'anuncio/:anuncioId',
            loadChildren: () => import('../anuncio-detalhe/anuncio-detalhe.module').then(m => m.DetalheAnuncioModule)
          },
          {
            path: 'detalhe-comerciante/:comercianteId',
            loadChildren: () => import('../detalhe-comerciante/detalhe-comerciante.module').then(m => m.DetalheComercianteModule)
          }
        ]
      },
      {
        path: 'mapa',
        children: [
          {
            path: '',
            loadChildren: () => import('../mapa/mapa.module').then(m => m.MapaModule)
          }
        ]
      },
      {
        path: 'sobre',
        children: [
          {
            path: '',
            loadChildren: () => import('../sobre/sobre.module').then(m => m.SobreModule)
          }
        ]
      },
      {
        path: '',
        redirectTo: '/app/abas/anuncios',
        pathMatch: 'full'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TelaAbasRoutingModule { }