import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AlertController } from '@ionic/angular';
import { UserData } from '../../providers/user-data';

@Component({
  selector: 'tela-perfil',
  templateUrl: 'perfil.html',
  styleUrls: ['./perfil.scss'],
})
export class TelaPerfil {
  username: string;

  constructor(
    public alertCtrl: AlertController,
    public router: Router,
    public userData: UserData
  ) { }

  trocarFoto() {
    console.log('');
  }

  sair() {
    this.userData.sair();
    this.router.navigateByUrl('/login');
  }

}