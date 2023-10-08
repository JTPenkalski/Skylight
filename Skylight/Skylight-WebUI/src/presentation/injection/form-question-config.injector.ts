import { InjectionToken, Provider } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { MatFormFieldAppearance } from '@angular/material/form-field';

export type FormQuestionConfiguration = {
  appearance: MatFormFieldAppearance,
  color: ThemePalette
};

// TOKEN
export const FORM_QUESTION_CONFIG_TOKEN = new InjectionToken<FormQuestionConfiguration>('FORM_QUESTION_CONFIG_TOKEN');

// SERVICE
export const FORM_QUESTION_CONFIG: FormQuestionConfiguration = {
  appearance: 'fill',
  color: 'accent'
}

// PROVIDER
export const FORM_QUESTION_CONFIG_PROVIDER: Provider[] = [
  { provide: FORM_QUESTION_CONFIG_TOKEN, useValue: FORM_QUESTION_CONFIG }
];