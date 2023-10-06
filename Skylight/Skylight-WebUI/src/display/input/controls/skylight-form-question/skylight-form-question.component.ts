import { Directive, EventEmitter, Inject, Input, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

import { ISkylightFormComponent } from './types';
import { FORM_QUESTION_CONFIG_TOKEN, FormQuestionConfiguration } from 'presentation/injection';
import { ErrorFormatterService } from 'display/input/services';
import { FormControlGuide } from 'web/models';
import { BehaviorSubject } from 'rxjs';

/**
 * Base Form Control for all individual Form Question components.
 * @requires [control]: The FormControl this component is linked to.
 **/
@Directive()
export abstract class SkylightFormQuestionComponent implements OnInit, ISkylightFormComponent {
  @Input() public label: string = '';
  @Input() public guide?: FormControlGuide;
  @Input({ required: true }) public control!: FormControl;

  @Output() public formGuideRequested: EventEmitter<undefined> = new EventEmitter<undefined>();

  /**
   * Indicates if this AbstractControl has the Required validator.
   **/
  public get required(): boolean { return this.control.hasValidator(Validators.required); }

  constructor(
    @Inject(FORM_QUESTION_CONFIG_TOKEN) public readonly config: FormQuestionConfiguration,
    public readonly errorFormatter: ErrorFormatterService
  ) { }

  public ngOnInit(): void {
    this.implementGuide();
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
   * Override this in subclasses to extend its behavior.
   * Remember to call this version to get all base features, if overriding.
   */
  protected implementGuide(): void {
    if (this.guide?.defaultValue) {
      this.control.setValue(this.guide?.defaultValue);
    }

    if (this.guide?.readOnly) {
      this.control.disable();
    }
  }
}
