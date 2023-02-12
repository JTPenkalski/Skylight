import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SkylightControlsModule } from 'components/controls/skylight-controls.module';
import { SkylightFormWeatherEventComponent } from './weather-event/skylight-form-weather-event/skylight-form-weather-event.component';

// TODO: Import form-specific service modules

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule, // TODO: DELETE THIS!
    ReactiveFormsModule,
    SkylightControlsModule
  ],
  declarations: [
    SkylightFormWeatherEventComponent
  ],
  exports: [
    SkylightFormWeatherEventComponent
  ]
})
export class SkylightFormsModule { }