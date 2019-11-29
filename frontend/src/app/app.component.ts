import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { SwUpdate } from '@angular/service-worker';
import { Events, MenuController, Platform, ToastController } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import { Storage } from '@ionic/storage';
import { UserData } from './providers/user-data';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent implements OnInit {
  appPages = [
    {
      title: 'Anúncios',
      url: '/app/abas/anuncios',
      icon: 'calendar'
    },
    {
      title: 'Comerciantes',
      url: '/app/abas/comerciantes',
      icon: 'contacts'
    },
    {
      title: 'Mapa',
      url: '/app/abas/mapa',
      icon: 'map'
    }
  ];
  loggedIn = false;

  constructor(
    private events: Events,
    private menu: MenuController,
    private platform: Platform,
    private router: Router,
    private splashScreen: SplashScreen,
    private statusBar: StatusBar,
    private storage: Storage,
    private userData: UserData,
    private swUpdate: SwUpdate,
    private toastCtrl: ToastController,
  ) {
    this.initializeApp();
  }

  async ngOnInit() {
    this.checkLoginStatus();
    this.listenForLoginEvents();
  }

  initializeApp() {
    this.platform.ready().then(() => {
      this.statusBar.styleDefault();
      this.splashScreen.hide();
    });
  }

  checkLoginStatus() {
    return this.userData.loggedIn().then(loggedIn => {
      return this.updateLoggedInStatus(loggedIn);
    });
  }

  updateLoggedInStatus(loggedIn: boolean) {
    setTimeout(() => {
      this.loggedIn = loggedIn;
    }, 300);
  }

  listenForLoginEvents() {
    this.events.subscribe('user:login', () => {
      this.updateLoggedInStatus(true);
    });

    this.events.subscribe('user:cadastro', () => {
      this.updateLoggedInStatus(true);
    });

    this.events.subscribe('user:sair', () => {
      this.updateLoggedInStatus(false);
    });
  }

  sair() {
    this.userData.sair().then(() => {
      return this.router.navigateByUrl('/login');
    });
  }

}