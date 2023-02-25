import { Directive, Inject, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { FormQuestionConfiguration, FORM_QUESTION_CONFIG_TOKEN } from './form-question-configuration.service';
import { IFormControlInstance } from './models/form-control-instance.model';

/**
 * Base component for all Form Question components.
 **/
@Directive()
export abstract class SkylightFormQuestionComponent {
  @Input() public label: string = '';
  @Input() public control: IFormControlInstance = { name: '', formControl: new FormControl() };

  public get required(): boolean { return this.control.formControl.hasValidator(Validators.required); }
  public get formGroup(): FormGroup { return this.control.formControl.parent as FormGroup; }

  constructor(@Inject(FORM_QUESTION_CONFIG_TOKEN) public readonly config: FormQuestionConfiguration) { }

  /**
   * Formats a specified validation message with this control's specific label.
   * @param message The message from the FormQuestionConfiguration's validation property.
   * @returns A formatted string to display for a validation error message.
   **/
  public formatError(message: string): string {
    return message.replace('{name}', this.label);
  }
}
