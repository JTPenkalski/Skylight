import { InjectionToken, Provider } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { MatFormFieldAppearance } from '@angular/material/form-field';

export type FormQuestionConfiguration = {
  appearance: MatFormFieldAppearance,
  color: ThemePalette,
  validation: {
    required: string
  }
};

// TOKEN
export const FORM_QUESTION_CONFIG_TOKEN = new InjectionToken<FormQuestionConfiguration>('FORM_QUESTION_CONFIG_TOKEN');

// SERVICE
export const FORM_QUESTION_CONFIG: FormQuestionConfiguration = {
  appearance: 'fill',
  color: 'accent',
  validation: {
    required: '{name} is a required field.'
  }
}

// PROVIDER
export const FORM_QUESTION_CONFIG_PROVIDER: Provider[] = [
  { provide: FORM_QUESTION_CONFIG_TOKEN, useValue: FORM_QUESTION_CONFIG }
];