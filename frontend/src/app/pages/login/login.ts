import { Component, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserData } from '../../providers/user-data';
import { UserOptions } from '../../interfaces/user-options';

@Component({
  selector: 'tela-login',
  templateUrl: 'login.html',
  styleUrls: ['./login.scss'],
})
export class TelaLogin {
  login: UserOptions = { username: '', password: '' };
  submitted = false;

  constructor(
    public userData: UserData,
    public router: Router
  ) { }

  aoLogar(form: NgForm) {
    this.submitted = true;

    if (form.valid) {
      this.userData.login(this.login.username);
      this.router.navigateByUrl('/app/abas/anuncios');
    }
  }

  aoCadastrar() {
    this.router.navigateByUrl('/cadastro');
  }
}