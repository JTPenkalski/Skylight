import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { DropdownWeatherAlertComponent } from '../dropdown-weather-alert/dropdown-weather-alert.component';

@NgModule({
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatSelectModule
  ],
  declarations: [
    DropdownWeatherAlertComponent
  ],
  exports: [
    DropdownWeatherAlertComponent
  ]
})
export class SkylightControlsModule { }
