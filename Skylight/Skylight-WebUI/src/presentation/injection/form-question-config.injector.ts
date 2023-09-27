import { InjectionToken, Provider } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { MatLegacyFormFieldAppearance as MatFormFieldAppearance } from '@angular/material/legacy-form-field';

export type FormQuestionConfiguration = {
  appearance: MatFormFieldAppearance,
  color: ThemePalette,
  validation: {
    required: string,
    zipCode: string
  }
};

// TOKEN
export const FORM_QUESTION_CONFIG_TOKEN = new InjectionToken<FormQuestionConfiguration>('FORM_QUESTION_CONFIG_TOKEN');

// SERVICE
export const FORM_QUESTION_CONFIG: FormQuestionConfiguration = {
  appearance: 'fill',
  color: 'accent',
  validation: {
    required: '{name} is a required field.',
    zipCode: '{name} must be a zip code with exactly 5 digits.'
  }
}

// PROVIDER
export const FORM_QUESTION_CONFIG_PROVIDER: Provider[] = [
  { provide: FORM_QUESTION_CONFIG_TOKEN, useValue: FORM_QUESTION_CONFIG }
];