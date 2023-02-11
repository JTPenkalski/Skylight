import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ReactiveFormsModule } from '@angular/forms';
import { SkylightServicesModule } from './skylight-services.module';

import { NavigationBarComponent } from 'components/containers/navigation-bar/navigation-bar.component';
import { MainComponent } from 'components/containers/main/main.component';

@NgModule({
  imports: [
    CommonModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    MatSidenavModule,
    MatToolbarModule,
    MatTooltipModule,
    ReactiveFormsModule,
    SkylightServicesModule
  ],
  declarations: [
    NavigationBarComponent,
    MainComponent
  ],
  exports: [
    NavigationBarComponent,
    MainComponent
  ]
})
export class SkylightControlsModule { }
