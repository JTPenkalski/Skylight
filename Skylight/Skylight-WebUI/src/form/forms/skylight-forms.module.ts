import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { SkylightControlsModule } from 'form/controls/skylight-controls.module';
import { SkylightServicesModule } from 'presentation/services/skylight-services.module';

import { FORM_QUESTION_CONFIG_PROVIDER } from 'presentation/injection';
import { LocationMapper, WeatherEventAlertMapper, WeatherEventMapper, WeatherEventStatisticsMapper } from 'presentation/services/mappers';
import { SkylightFormWeatherEventComponent } from 'form/forms/skylight-form-weather-event/skylight-form-weather-event.component';
import { WeatherEventService } from 'presentation/services/backend-services';
import { HttpControllerClient } from 'presentation/services/clients';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SkylightControlsModule,
    SkylightServicesModule
  ],
  declarations: [
    SkylightFormWeatherEventComponent
  ],
  exports: [
    SkylightFormWeatherEventComponent
  ],
  providers: [
    FORM_QUESTION_CONFIG_PROVIDER,

    HttpControllerClient,

    LocationMapper,
    WeatherEventAlertMapper,
    WeatherEventMapper,
    WeatherEventStatisticsMapper,

    WeatherEventService
  ]
})
export class SkylightFormsModule { }