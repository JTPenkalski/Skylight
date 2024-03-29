import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { environment } from 'core/environments/environment';

import * as Clients from './index';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule
  ],
  declarations: [],
  exports: [],
  providers: [
    { provide: Clients.API_BASE_URL, useValue: environment.apiUrl },

    Clients.FormGuideClient,
    Clients.LocationClient,
    Clients.WeatherClient,
    Clients.WeatherAlertClient,
    Clients.WeatherAlertModifierClient,
    Clients.WeatherEventClient,
    Clients.WeatherExperienceClient
  ]
})
export class SkylightWebClientsModule { }