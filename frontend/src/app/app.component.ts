import { Component } from '@angular/core';
import { Platform, NavController } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import { Pages } from './interfaces/pages';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  public appPages: Array<Pages>;

  constructor(
    private platform: Platform,
    private splashScreen: SplashScreen,
    private statusBar: StatusBar,
    public navCtrl: NavController
  ) {
    this.appPages = [
      {
        title: 'Início',
        url: '/home-results',
        direct: 'root',
        icon: 'home'
      },
      {
        title: 'Meu Perfil',
        url: '/edit-profile',
        direct: 'forward',
        icon: 'contact'
      },
      {
        title: 'Sair',
        url: '',
        direct: 'forward',
        icon: 'log-out'
      }
    ];

    this.initializeApp();
  }

  initializeApp() {
    this.platform.ready().then(() => {
      this.statusBar.styleDefault();
      this.splashScreen.hide();
    }).catch(() => { });
  }

  logout() {
    this.navCtrl.navigateRoot('/');
  }
}