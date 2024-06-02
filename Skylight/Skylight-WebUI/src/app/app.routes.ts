import { Routes } from '@angular/router';
import { NotFoundPageComponent, RegisterPageComponent, SignInPageComponent, WeatherEventPageComponent } from 'pages';

export const routes: Routes = [
  { path: 'register', component: RegisterPageComponent },
  { path: 'sign-in', component: SignInPageComponent },
  { path: 'weather-event', component: WeatherEventPageComponent },
  { path: '', redirectTo: '/weather-event', pathMatch: 'full' },
  { path: 'not-found', component: NotFoundPageComponent },
  { path: '**', component: NotFoundPageComponent },
];
