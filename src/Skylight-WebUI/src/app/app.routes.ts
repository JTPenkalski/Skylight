import { Routes } from '@angular/router';
import {
  AllWeatherEventsPageComponent,
  HomePageComponent,
  NotFoundPageComponent,
  RegisterPageComponent,
  SignInPageComponent,
  WeatherEventPageComponent,
} from 'pages';
import { authenticatedGuard } from 'shared/guards';

export const routes: Routes = [
  { path: 'register', component: RegisterPageComponent },
  { path: 'sign-in', component: SignInPageComponent },
  { path: 'home', component: HomePageComponent },
  {
    path: 'weather-event',
    component: WeatherEventPageComponent,
    canActivate: [authenticatedGuard],
  },
  {
    path: 'weather-events',
    component: AllWeatherEventsPageComponent,
    canActivate: [authenticatedGuard],
  },
  {
    path: '',
    redirectTo: '/weather-events',
    pathMatch: 'full',
  },
  { path: 'not-found', component: NotFoundPageComponent },
  { path: '**', component: NotFoundPageComponent },
];
