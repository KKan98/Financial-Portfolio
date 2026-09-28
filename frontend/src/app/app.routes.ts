import { Routes } from '@angular/router';
import { Home } from './home/home';
import { Login } from './auth/login/login';
import { Signup } from './auth/signup/signup';
import { authGuard } from './auth/auth.guard';
import { Dashboard } from './portfolio/dashboard/dashboard';

export const routes: Routes = [
  {
    path: '',
    component: Home
  },
  {
    path: 'dashboard',
    component: Dashboard,
    canActivate: [authGuard]
  },
  {
    path: 'login',
    component: Login
  },
  {
    path: 'signup',
    component: Signup
  },
  {
    path: '**',
    component: Login
  }
];
