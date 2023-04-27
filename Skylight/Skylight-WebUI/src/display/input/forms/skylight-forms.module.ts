import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { SkylightControlsModule } from 'display/input/controls/skylight-controls.module';

import { FORM_QUESTION_CONFIG_PROVIDER } from 'presentation/injection';

import { SkylightFormWeatherEventComponent } from 'display/input/forms/skylight-form-weather-event/skylight-form-weather-event.component';

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
    ...FORM_QUESTION_CONFIG_PROVIDER
  ]
})
export class SkylightFormsModule { }