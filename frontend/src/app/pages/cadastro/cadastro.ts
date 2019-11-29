import { Component, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { UserData } from '../../providers/user-data';
import { UserOptions } from '../../interfaces/user-options';
import { reject } from 'q';
import { ToastController } from '@ionic/angular';

@Component({
  selector: 'page-cadastro',
  templateUrl: 'cadastro.html',
  styleUrls: ['./cadastro.scss'],
})
export class TelaCadastro {
  cadastro: UserOptions = { username: '', password: '' };
  submitted = false;
  data = undefined;

  constructor(
    public router: Router,
    public userData: UserData,
    public http: HttpClient,
    private readonly toastController: ToastController
  ) {
    console.log('');
  }

  async presentToast(message: string) {
    const toast = await this.toastController.create({
      message: message,
      duration: 3000
    });
    toast.present();
  }

  aoCadastrar() {
    if (this.data) {
      return Promise.resolve(this.data);
    }

    return new Promise(resolve => {

      var dados = { "username": this.cadastro.username, "password": this.cadastro.password }

      // this.http.put('https://cors-anywhere.herokuapp.com/https://querocento.herokuapp.com/api/usuarios', dados)
      this.http.put('http://qnotpgzdes049.quiver.local/querocento/api/usuarios', dados)
        .subscribe(data => {
          this.data = data
          resolve(this.data);
          this.router.navigateByUrl('/app/abas/anuncios');
        },
          (error) => {
            this.presentToast('Erro!');
          });
    });
  }
}