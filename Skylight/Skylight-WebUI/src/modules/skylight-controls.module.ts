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

import { FormLocationComponent } from '../components/forms/location/form-location.component'; // TODO: Extra forms to own Angular Module?
import { NavigationBarComponent } from '../components/layout/navigation-bar/navigation-bar.component';
import { DynamicFormsModule } from './dynamic-forms.module';
import { DynamicFormComponent } from '../components/forms/dynamic-form/dynamic-form.component';
import { DropdownQuestionComponent } from '../components/controls/dynamic-forms/dropdown-question/dropdown-question.component';

@NgModule({
  imports: [
    CommonModule,
    DynamicFormsModule,
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
    DynamicFormComponent,
    DropdownQuestionComponent,
    FormLocationComponent,
    NavigationBarComponent
  ],
  exports: [
    DynamicFormComponent,
    DropdownQuestionComponent,
    FormLocationComponent,
    NavigationBarComponent
  ]
})
export class SkylightControlsModule { }
