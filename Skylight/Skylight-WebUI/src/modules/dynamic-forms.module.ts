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

import { DynamicFormComponent } from '../components/containers/dynamic-form/dynamic-form.component';
import { DynamicFormSectionComponent } from '../components/containers/dynamic-form-section/dynamic-form-section.component';
import { DropdownQuestionComponent } from '../components/controls/dynamic-forms/dropdown-question/dropdown-question.component';
import { DynamicFormLoaderService } from '../services/dynamic-forms/dynamic-form-loader.service';
import { DynamicFormQuestionDirective } from '../components/controls/dynamic-forms/dynamic-form-question/dynamic-form-question.component';

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
    ReactiveFormsModule
  ],
  declarations: [
    DynamicFormComponent,
    DynamicFormSectionComponent,
    DynamicFormQuestionDirective,
    DropdownQuestionComponent
  ],
  exports: [
    DynamicFormComponent,
    DynamicFormSectionComponent,
    DynamicFormQuestionDirective,
    DropdownQuestionComponent
  ],
  providers: [
    DynamicFormLoaderService
  ]
})
export class DynamicFormsModule { }
