import { Directive, Inject, Input } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

import { ISkylightFormQuestion } from './types';
import { FORM_QUESTION_CONFIG_TOKEN, FormQuestionConfiguration } from 'presentation/injection';
import { ErrorFormatterService } from 'display/input/services';

/**
 * Base Form Control for all individual Form Question components.
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
    @Inject(FORM_QUESTION_CONFIG_TOKEN) public readonly config: FormQuestionConfiguration,
    public readonly errorFormatter: ErrorFormatterService
  ) { }
}
