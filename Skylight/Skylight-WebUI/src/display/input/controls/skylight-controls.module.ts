import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MatLegacyButtonModule as MatButtonModule } from '@angular/material/legacy-button';
import { MatLegacyCheckboxModule as MatCheckboxModule } from '@angular/material/legacy-checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatLegacyFormFieldModule as MatFormFieldModule } from '@angular/material/legacy-form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatLegacyInputModule as MatInputModule } from '@angular/material/legacy-input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatLegacySelectModule as MatSelectModule } from '@angular/material/legacy-select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatLegacyTooltipModule as MatTooltipModule } from '@angular/material/legacy-tooltip';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { FORM_QUESTION_CONFIG_PROVIDER } from 'presentation/injection';

import { SkylightReorderableListItemDirective } from './skylight-reorderable-list/skylight-reorderable-list-item.directive';

import * as SkylightFormQuestions from './skylight-form-question';
import { SkylightSearchBarComponent } from 'display/input/controls/skylight-search-bar/skylight-search-bar.component';
import { SkylightFormFieldSetComponent } from './skylight-form-field-set/skylight-form-field-set.component';
import { SkylightReorderableListComponent } from './skylight-reorderable-list/skylight-reorderable-list.component';

@NgModule({
  imports: [
    CommonModule,
    DragDropModule,
    FormsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatNativeDateModule,
    MatSelectModule,
    MatSidenavModule,
    MatToolbarModule,
    MatTooltipModule,
    ReactiveFormsModule
  ],
  declarations: [
    SkylightReorderableListItemDirective,
    SkylightFormQuestions.SkylightFormQuestionCheckboxComponent,
    SkylightFormQuestions.SkylightFormQuestionDateComponent,
    SkylightFormQuestions.SkylightFormQuestionInputComponent,
    SkylightFormQuestions.SkylightFormQuestionSelectComponent,
    SkylightFormQuestions.SkylightFormQuestionTextAreaComponent,
    SkylightFormQuestions.SkylightFormQuestionLocationComponent,
    SkylightFormQuestions.SkylightFormQuestionWeatherEventAlertComponent,
    SkylightFormQuestions.SkylightFormQuestionWeatherEventStatisticsComponent,
    SkylightSearchBarComponent,
    SkylightFormFieldSetComponent,
    SkylightReorderableListComponent,
  ],
  exports: [
    MatButtonModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatNativeDateModule,
    MatSelectModule,
    MatSidenavModule,
    MatToolbarModule,
    MatTooltipModule,
    SkylightReorderableListItemDirective,
    SkylightFormQuestions.SkylightFormQuestionDateComponent,
    SkylightFormQuestions.SkylightFormQuestionInputComponent,
    SkylightFormQuestions.SkylightFormQuestionSelectComponent,
    SkylightFormQuestions.SkylightFormQuestionTextAreaComponent,
    SkylightFormQuestions.SkylightFormQuestionWeatherEventAlertComponent,
    SkylightFormQuestions.SkylightFormQuestionLocationComponent,
    SkylightFormQuestions.SkylightFormQuestionWeatherEventStatisticsComponent,
    SkylightSearchBarComponent,
    SkylightFormFieldSetComponent,
    SkylightReorderableListComponent
  ],
  providers: [
    ...FORM_QUESTION_CONFIG_PROVIDER
  ]
})
export class SkylightControlsModule { }
