import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { WeatherAlertsService } from '../services/weather-alerts.service';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [
    WeatherAlertsService
  ]
})
export class SkylightServicesModule { }
