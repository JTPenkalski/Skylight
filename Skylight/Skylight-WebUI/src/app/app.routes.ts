import { Routes } from '@angular/router';
import { NotFoundPageComponent, RegisterPageComponent, WeatherEventPageComponent } from 'pages';

export const routes: Routes = [
  { path: 'weather-event', component: WeatherEventPageComponent },
  { path: 'register', component: RegisterPageComponent },
  { path: '', redirectTo: '/weather-event', pathMatch: 'full' },
  { path: 'not-found', component: NotFoundPageComponent },
  { path: '**', component: NotFoundPageComponent },
];
