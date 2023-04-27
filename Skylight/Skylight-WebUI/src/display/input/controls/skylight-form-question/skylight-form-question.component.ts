import { Directive, Inject, Input } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

import { ISkylightFormQuestion } from './types';
import { FORM_QUESTION_CONFIG, FormQuestionConfiguration } from 'presentation/injection';

/**
 * Base Form Field for all individual Form Question controls.
 * @requires [control]: The FormControl this component is linked to.
 **/
@Directive()
export abstract class SkylightFormQuestionComponent implements ISkylightFormQuestion {
  @Input() public label: string = '';
  @Input() public control!: FormControl;

  /**
   * Indicates if this AbstractControl has the Required validator.
   **/
  public get required(): boolean { return this.control.hasValidator(Validators.required); }

  constructor(
    @Inject(FORM_QUESTION_CONFIG) public readonly config: FormQuestionConfiguration,
  ) { }

  /**
   * Formats a specified validation message with this control's specific label.
   * @param message The message from the FormQuestionConfiguration's validation property.
   * @returns A formatted string to display for a validation error message.
   **/
  public formatError(message: string): string {
    return message.replace('{name}', this.label);
  }
}
