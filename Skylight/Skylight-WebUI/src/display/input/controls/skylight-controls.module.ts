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

import { FORM_QUESTION_CONFIG_PROVIDER } from 'presentation/injection';

import { SkylightSearchBarComponent } from 'display/input/controls/skylight-search-bar/skylight-search-bar.component';
import * as SkylightFormQuestions from './skylight-form-questions';

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
    SkylightFormQuestions.SkylightFormQuestionDateComponent,
    SkylightFormQuestions.SkylightFormQuestionInputComponent,
    SkylightFormQuestions.SkylightFormQuestionSelectComponent,
    SkylightFormQuestions.SkylightFormQuestionTextAreaComponent,
    SkylightFormQuestions.SkylightFormQuestionWeatherEventAlertComponent
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
    SkylightFormQuestions.SkylightFormQuestionDateComponent,
    SkylightFormQuestions.SkylightFormQuestionInputComponent,
    SkylightFormQuestions.SkylightFormQuestionSelectComponent,
    SkylightFormQuestions.SkylightFormQuestionTextAreaComponent,
    SkylightFormQuestions.SkylightFormQuestionWeatherEventAlertComponent
  ],
  providers: [
    ...FORM_QUESTION_CONFIG_PROVIDER
  ]
})
export class SkylightControlsModule { }
