import { InjectionToken, Provider } from '@angular/core';
import { Routes } from '@angular/router';

// Inputs
import { SkylightFormWeatherEventComponent } from 'display/input/forms/skylight-form-weather-event/skylight-form-weather-event.component';

// Views
import { WelcomePageComponent } from 'display/view/pages/welcome-page/welcome-page.component';
import { ErrorPageComponent } from 'display/view/pages/error-page/error-page.component';

export type RouteNamesConfiguration = {
  root: '',
  default: '**',
  weatherEvent: {
    new: string;
    single: string;
    all: string;
  }
};

// TOKENS
export const ROUTE_NAMES_CONFIG_TOKEN = new InjectionToken<RouteNamesConfiguration>('ROUTE_NAMES_CONFIG_TOKEN');
export const ROUTES_CONFIG_TOKEN = new InjectionToken<Routes>('ROUTES_CONFIG_TOKEN');

// SERVICES
export const ROUTE_NAMES_CONFIG: RouteNamesConfiguration = {
  root: '',
  weatherEvent: {
    new: 'weather-events/new',
    single: 'weather-events/{id}',
    all: 'weather-events'
  },
  default: '**'
}

export const ROUTES_CONFIG: Routes = [
  { path: ROUTE_NAMES_CONFIG.root, component: WelcomePageComponent },
  { path: ROUTE_NAMES_CONFIG.weatherEvent.new, component: SkylightFormWeatherEventComponent, title: "New Weather Event" },
  { path: ROUTE_NAMES_CONFIG.default, component: ErrorPageComponent, title: 'Not Found' }
]

// PROVIDERS
export const ROUTE_NAMES_CONFIG_PROVIDER: Provider[] = [
  { provide: ROUTE_NAMES_CONFIG_TOKEN, useValue: ROUTE_NAMES_CONFIG }
];

export const ROUTES_CONFIG_PROVIDER: Provider[] = [
  { provide: ROUTES_CONFIG_TOKEN, useValue: ROUTES_CONFIG }
];