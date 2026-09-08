import { Routes } from '@angular/router';
import { Home } from './home/home';
import { Auth } from './auth/auth';

export const routes: Routes = [
  {
    path: '',
    component: Home
  },
  {
    path: 'login',
    component: Auth
  }
];
