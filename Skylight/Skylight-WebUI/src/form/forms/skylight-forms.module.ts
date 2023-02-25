import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { SkylightControlsModule } from 'form/controls/skylight-controls.module';

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
  ]
})
export class SkylightFormsModule { }