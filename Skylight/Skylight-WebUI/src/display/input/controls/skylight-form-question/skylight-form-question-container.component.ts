import { Directive, Inject, Input } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';

import { ISkylightFormQuestionContainer } from './types';
import { FORM_QUESTION_CONFIG, FormQuestionConfiguration } from 'presentation/injection';
import { ErrorFormatterService } from 'display/input/services';
import { IBaseModel } from 'display/input/models';

/**
 * Base Form Group for multiple Form Question controls.
 * @requires [group]: The FormGroup this component is linked to.
 **/
@Directive()
export abstract class SkylightFormQuestionContainerComponent<T extends IBaseModel> implements ISkylightFormQuestionContainer {
  @Input() public label: string = '';
  @Input() public group!: FormGroup<T>;

  /**
   * Indicates if this AbstractControl has the Required validator.
   **/
  public get required(): boolean { return this.group.hasValidator(Validators.required); }

  constructor(
    @Inject(FORM_QUESTION_CONFIG) public readonly config: FormQuestionConfiguration,
    public readonly errorFormatter: ErrorFormatterService
  ) { }
}