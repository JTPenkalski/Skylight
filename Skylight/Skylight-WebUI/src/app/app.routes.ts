import { Routes } from '@angular/router';
import { NotFoundPageComponent, RegisterPageComponent, SignInPageComponent, WeatherEventPageComponent } from 'pages';
import { authenticatedGuard } from 'shared/guards';

export const routes: Routes = [
  { path: 'register', component: RegisterPageComponent },
  { path: 'sign-in', component: SignInPageComponent },
  { path: 'weather-event', component: WeatherEventPageComponent, canActivate: [authenticatedGuard] },
  { path: '', redirectTo: '/weather-event', pathMatch: 'full' },
  { path: 'not-found', component: NotFoundPageComponent },
  { path: '**', component: NotFoundPageComponent },
];
