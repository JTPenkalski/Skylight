import { Directive, EventEmitter, Inject, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormControl, ValidatorFn, Validators } from '@angular/forms';

import { ISkylightFormComponent } from './types';
import { FORM_QUESTION_CONFIG_TOKEN, FormQuestionConfiguration } from 'presentation/injection';
import { ErrorFormatterService } from 'display/input/services';
import { FormControlGuide, FormControlValidation } from 'web/models';
import { CustomValidators } from 'display/input/validators';

/**
 * Base Form Control for all individual Form Question components.
 * @requires [control]: The FormControl this component is linked to.
 **/
@Directive()
export abstract class SkylightFormQuestionComponent implements OnInit, OnChanges, ISkylightFormComponent {
  @Input() public label: string = '';
  @Input() public hint?: string;
  @Input() public example?: string;
  @Input() public guide?: FormControlGuide;
  @Input({ required: true }) public control!: FormControl;

  @Output() public formGuideRequested: EventEmitter<undefined> = new EventEmitter<undefined>();

  constructor(
    @Inject(FORM_QUESTION_CONFIG_TOKEN) public readonly config: FormQuestionConfiguration,
    public readonly errorFormatter: ErrorFormatterService
  ) { }

  public get errorMessage(): string {
    return this.guide?.validation && this.control.errors
      ? this.errorFormatter.formatErrors({
          controlName: this.label,
          validation: this.guide.validation,
          errors: this.control.errors,
          expectedFormat: this.example
        })
      : '';    
  }

  public ngOnInit(): void {
    this.implementGuide();
  }

  public ngOnChanges(changes: SimpleChanges): void {
    // If the guide changed, implement the updated data
    if (changes['guide']) {
      this.implementGuide();
    }
  }

  public requestFormGuide(): void {
    this.formGuideRequested.emit();
  }

  /**
   * Prevents 'mouse down' events from propagating to cdkDrag handlers when moused over controls.
   * @param event The DOM event triggered for this element.
   */
  public blockDrag(event: Event): void {
    event.stopPropagation();
  }

  /**
   * This function is executed when a new guide value is detected, as set up in ngOnInit().
   * Only override this in subclasses to completely extend its behavior for total customization.
   * Otherwise, override the necessary helper function below.
   */
  protected implementGuide(): void {
    // Default Value
    if (this.guide?.defaultValue) {
      this.setDefaultValue(this.guide.defaultValue);
    }

    // Read Only
    if (this.guide?.readOnly) {
      this.setReadOnly();
    }

    // Validation
    if (this.guide?.validation) {
      this.setValidators(this.guide.validation);
    }
  }

  /**
   * Dynamically set the value of this control.
   * @param value The new value of this control.
   */
  protected setDefaultValue(value: any): void {
    this.control.setValue(value);
  }

  /**
   * Dynamically sets the read-only status of this control.
   */
  protected setReadOnly(): void {
    this.control.disable();
  }

  /**
   * Dynamically set the validators of this control.
   * @param validation The validators of this control, from the guide.
   */
  protected setValidators(validation: FormControlValidation): void {
    const validators: ValidatorFn[] = [];

    // Required
    if (validation.required) {
      validators.push(Validators.required);
    }

    // Regex Pattern
    if (validation.pattern) {
      validators.push(Validators.pattern(validation.pattern));
    }

    // Min Length
    if (validation.stringValidation?.minLength) {
      validators.push(Validators.minLength(validation.stringValidation.minLength));
    }

    // Max Length
    if (validation.stringValidation?.maxLength) {
      validators.push(Validators.maxLength(validation.stringValidation.maxLength));
    }

    // Min Numeric Value
    if (validation.numericValidation?.minValue) {
      validators.push(Validators.min(validation.numericValidation.minValue));
    }

    // Max Numeric Value
    if (validation.numericValidation?.maxValue) {
      validators.push(Validators.max(validation.numericValidation.maxValue));
    }

    // Min Date Value
    if (validation.dateTimeValidation?.minValue) {
      validators.push(CustomValidators.minDate(validation.dateTimeValidation.minValue));
    }

    // Max Date Value
    if (validation.dateTimeValidation?.maxValue) {
      validators.push(CustomValidators.maxDate(validation.dateTimeValidation.maxValue));
    }

    this.control.setValidators(validators);
  }
}
