import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

import { SkylightControlsModule } from 'components/controls/skylight-controls.module';
import { SkylightFormWeatherEventComponent } from 'components/forms/skylight-form-weather-event/skylight-form-weather-event.component';

// TODO: Import form-specific service modules

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SkylightControlsModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  declarations: [
    SkylightFormWeatherEventComponent
  ],
  exports: [
    SkylightFormWeatherEventComponent
  ]
})
export class SkylightFormsModule { }