import { Routes } from '@angular/router';
import { NotFoundPageComponent, WeatherEventPageComponent } from 'pages';

export const routes: Routes = [
  { path: 'weather-event', component: WeatherEventPageComponent },
  { path: '', redirectTo: '/weather-event', pathMatch: 'full' },
  { path: '**', component: NotFoundPageComponent },
];
