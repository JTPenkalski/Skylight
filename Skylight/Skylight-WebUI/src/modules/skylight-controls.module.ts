import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ReactiveFormsModule } from '@angular/forms';
import { SkylightServicesModule } from './skylight-services.module';

import { DropdownWeatherAlertComponent } from '../components/dropdown-weather-alert/dropdown-weather-alert.component';
import { FormLocationComponent } from '../components/forms/location/form-location.component'; // TODO: Extra forms to own Angular Module?
import { NavigationBarComponent } from '../components/navigation-bar/navigation-bar.component';

@NgModule({
  imports: [
    CommonModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    MatToolbarModule,
    MatTooltipModule,
    ReactiveFormsModule,
    SkylightServicesModule
  ],
  declarations: [
    DropdownWeatherAlertComponent,
    FormLocationComponent,
    NavigationBarComponent
  ],
  exports: [
    DropdownWeatherAlertComponent,
    FormLocationComponent,
    NavigationBarComponent
  ]
})
export class SkylightControlsModule { }
