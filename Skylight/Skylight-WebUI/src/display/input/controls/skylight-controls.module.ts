import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DragDropModule } from '@angular/cdk/drag-drop';
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

import * as SkylightFormQuestions from './skylight-form-questions';
import { SkylightSearchBarComponent } from 'display/input/controls/skylight-search-bar/skylight-search-bar.component';
import { SkylightFormFieldSetComponent } from './skylight-form-field-set/skylight-form-field-set.component';
import { SkylightReorderableListComponent } from './skylight-reorderable-list/skylight-reorderable-list.component';

@NgModule({
  imports: [
    CommonModule,
    DragDropModule,
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
    SkylightFormQuestions.SkylightFormQuestionDateComponent,
    SkylightFormQuestions.SkylightFormQuestionInputComponent,
    SkylightFormQuestions.SkylightFormQuestionSelectComponent,
    SkylightFormQuestions.SkylightFormQuestionTextAreaComponent,
    SkylightFormQuestions.SkylightFormQuestionWeatherEventAlertComponent,
    SkylightFormQuestions.SkylightFormQuestionLocationComponent,
    SkylightSearchBarComponent,
    SkylightFormFieldSetComponent,
    SkylightReorderableListComponent
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
    SkylightFormQuestions.SkylightFormQuestionDateComponent,
    SkylightFormQuestions.SkylightFormQuestionInputComponent,
    SkylightFormQuestions.SkylightFormQuestionSelectComponent,
    SkylightFormQuestions.SkylightFormQuestionTextAreaComponent,
    SkylightFormQuestions.SkylightFormQuestionWeatherEventAlertComponent,
    SkylightFormQuestions.SkylightFormQuestionLocationComponent,
    SkylightSearchBarComponent,
    SkylightFormFieldSetComponent,
    SkylightReorderableListComponent
  ],
  providers: [
    ...FORM_QUESTION_CONFIG_PROVIDER
  ]
})
export class SkylightControlsModule { }
