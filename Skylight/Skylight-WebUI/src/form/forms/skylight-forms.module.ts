import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { SkylightControlsModule } from 'form/controls/skylight-controls.module';

import { REQUESTORS } from 'presentation/injection/requestors.injector';
import { LocationMapper, WeatherEventAlertMapper, WeatherEventMapper, WeatherEventStatisticsMapper } from 'form/form-models/mappers';
import { SkylightFormWeatherEventComponent } from 'form/forms/skylight-form-weather-event/skylight-form-weather-event.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SkylightControlsModule
  ],
  declarations: [
    SkylightFormWeatherEventComponent
  ],
  exports: [
    SkylightFormWeatherEventComponent
  ],
  providers: [
    ...REQUESTORS, // TODO: Why is this here?
    LocationMapper,
    WeatherEventAlertMapper,
    WeatherEventMapper,
    WeatherEventStatisticsMapper
  ]
})
export class SkylightFormsModule { }