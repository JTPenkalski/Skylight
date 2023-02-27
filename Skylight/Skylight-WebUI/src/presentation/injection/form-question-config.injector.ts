import { InjectionToken, Provider } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { MatFormFieldAppearance } from '@angular/material/form-field';

// TOKEN
export const FORM_QUESTION_CONFIG = new InjectionToken<FormQuestionConfiguration>('FORM_QUESTION_CONFIG_TOKEN');

// SERVICE
export type FormQuestionConfiguration = {
  appearance: MatFormFieldAppearance,
  color: ThemePalette,
  validation: {
    required: string
  }
};

export const CONFIG: FormQuestionConfiguration = {
  appearance: 'fill',
  color: 'accent',
  validation: {
    required: '{name} is a required field.'
  }
}

// PROVIDER
export const FORM_QUESTION_CONFIG_PROVIDER: Provider[] = [
  { provide: FORM_QUESTION_CONFIG, useValue: CONFIG }
];