import { Component, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { UserData } from '../../providers/user-data';
import { UserOptions } from '../../interfaces/user-options';
import { Observable } from 'rxjs';
import { ToastController } from '@ionic/angular';

@Component({
  selector: 'tela-login',
  templateUrl: 'login.html',
  styleUrls: ['./login.scss'],
})
export class TelaLogin {
  login: UserOptions = { username: '', password: '' };
  submitted = false;
  data = undefined;
  // API_URL = 'https://cors-anywhere.herokuapp.com/https://querocento.herokuapp.com/api/usuarios';
  API_URL = 'https://cors-anywhere.herokuapp.com/http://qnotpgzdes049.quiver.local/querocento/api/login';

  constructor(
    public userData: UserData,
    public router: Router,
    public http: HttpClient,
    private readonly toastController: ToastController
  ) { }

  async presentToast(message: string) {
    const toast = await this.toastController.create({
      message: message,
      duration: 3000
    });
    toast.present();
  }

  aoLogar(form: NgForm) {
    this.outroLogin(form).subscribe(async (status: string) => {
      if (status && status === '200') {
        this.router.navigateByUrl('/app/abas/anuncios');
      } else {
        this.presentToast('Login Incorreto!');
      }
    })
  }

  outroLogin(form: NgForm): Observable<any> {
    return this.http.post<NgForm>(
      `${this.API_URL}/api/login`,
      this.login
    )
  }

  // this.submitted = true;

  // if (form.valid) {
  //   this.userData.login(this.login.username);
  //   this.router.navigateByUrl('/app/abas/anuncios');
  // }

  aoCadastrar() {
    this.router.navigateByUrl('/cadastro');
  }
}