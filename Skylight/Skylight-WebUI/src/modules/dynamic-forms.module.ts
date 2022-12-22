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

import { DynamicFormLoaderService } from '../services/dynamic-forms/dynamic-form-loader.service';
import { DynamicFormCreatorService } from 'src/services/dynamic-forms/dynamic-form-creator.service';
import { DynamicFormComponent } from '../components/containers/dynamic-form/dynamic-form.component';
import { DynamicFormSectionComponent } from '../components/containers/dynamic-form-section/dynamic-form-section.component';
import { DynamicFormQuestionDirective } from '../components/controls/dynamic-forms/dynamic-form-question/dynamic-form-question.component';
import { DropdownQuestionComponent } from '../components/controls/dynamic-forms/dropdown-question/dropdown-question.component';
import { TextboxQuestionComponent } from 'src/components/controls/dynamic-forms/textbox-question/textbox-question.component';

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
    DropdownQuestionComponent,
    TextboxQuestionComponent
  ],
  exports: [
    DynamicFormComponent,
    DynamicFormSectionComponent,
    DynamicFormQuestionDirective,
    DropdownQuestionComponent,
    TextboxQuestionComponent
  ],
  providers: [
    DynamicFormLoaderService,
    DynamicFormCreatorService
  ]
})
export class DynamicFormsModule { }
