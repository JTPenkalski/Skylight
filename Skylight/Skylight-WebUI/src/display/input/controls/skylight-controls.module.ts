import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
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
