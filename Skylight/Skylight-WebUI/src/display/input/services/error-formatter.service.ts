import { Inject, Injectable } from '@angular/core';

import { FORM_QUESTION_CONFIG_TOKEN, FormQuestionConfiguration } from 'presentation/injection';

/**
 * Formats common error messages to display during form validation.
 **/
@Injectable({
  providedIn: 'root'
})
export class ErrorFormatterService {
  constructor(
    @Inject(FORM_QUESTION_CONFIG_TOKEN) public readonly config: FormQuestionConfiguration,
  ) { }
  
  /**
   * Generates a formatted error message for required validators.
   * @param name The name of the control that is required.
   * @returns The formatted error message.
   **/
  public required(name: string): string { return this.config.validation.required.replace('{name}', name || 'This control '); }
}
