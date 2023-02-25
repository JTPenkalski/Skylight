import { InjectionToken } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { MatFormFieldAppearance } from '@angular/material/form-field';

export type FormQuestionConfiguration = {
  appearance: MatFormFieldAppearance,
  color: ThemePalette,
  validation: {
    required: string
  }
};

export const FORM_QUESTION_CONFIG = {
  appearance: 'fill',
  color: 'accent',
  validation: {
    required: '{name} is a required field.'
  }
}

export const FORM_QUESTION_CONFIG_TOKEN = new InjectionToken<FormQuestionConfiguration>('FORM_QUESTION_CONFIG_TOKEN');
