import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { FORM_QUESTION_CONFIG, FORM_QUESTION_CONFIG_TOKEN } from './skylight-form-question/form-question-configuration.service';
import { SkylightSearchBarComponent } from 'form/controls/skylight-search-bar/skylight-search-bar.component';
import { SkylightFormQuestionDateComponent } from 'form/controls/skylight-form-question/skylight-form-question-date/skylight-form-question-date.component';
import { SkylightFormQuestionInputComponent } from 'form/controls/skylight-form-question/skylight-form-question-input/skylight-form-question-input.component';
import { SkylightFormQuestionSelectComponent } from 'form/controls/skylight-form-question/skylight-form-question-select/skylight-form-question-select.component';
import { SkylightFormQuestionTextAreaComponent } from 'form/controls/skylight-form-question/skylight-form-question-textarea/skylight-form-question-textarea.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatNativeDateModule,
    MatSelectModule,
    MatSidenavModule,
    MatToolbarModule,
    MatTooltipModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  declarations: [
    SkylightSearchBarComponent,
    SkylightFormQuestionDateComponent,
    SkylightFormQuestionInputComponent,
    SkylightFormQuestionSelectComponent,
    SkylightFormQuestionTextAreaComponent
  ],
  exports: [
    MatButtonModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatNativeDateModule,
    MatSelectModule,
    MatSidenavModule,
    MatToolbarModule,
    MatTooltipModule,
    SkylightSearchBarComponent,
    SkylightFormQuestionDateComponent,
    SkylightFormQuestionInputComponent,
    SkylightFormQuestionSelectComponent,
    SkylightFormQuestionTextAreaComponent
  ],
  providers: [
    { provide: FORM_QUESTION_CONFIG_TOKEN, useValue: FORM_QUESTION_CONFIG }
  ]
})
export class SkylightControlsModule { }
