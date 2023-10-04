import { AfterViewInit, Directive, EventEmitter, Inject, Input, Output, QueryList, ViewChildren } from '@angular/core';
import { FormGroup, Validators } from '@angular/forms';

import { ISkylightFormComponent } from './types';
import { FORM_QUESTION_CONFIG_TOKEN, FormQuestionConfiguration } from 'presentation/injection';
import { ErrorFormatterService } from 'display/input/services';
import { IBaseModel } from 'display/input/models';
import { SkylightFormQuestionComponent } from './skylight-form-question.component';

/**
 * Base Form Group for multiple Form Question controls.
 * @requires [group]: The FormGroup this component is linked to.
 **/
@Directive()
export abstract class SkylightFormQuestionContainerComponent<T extends IBaseModel> implements ISkylightFormComponent, AfterViewInit {
  @Input() public label: string = '';
  @Input({ required: true }) public group!: FormGroup<T>;

  @Output() public formGuideRequested: EventEmitter<undefined> = new EventEmitter<undefined>();
  
  @ViewChildren(SkylightFormQuestionComponent) private children!: QueryList<SkylightFormQuestionComponent>;

  /**
   * Indicates if this AbstractControl has the Required validator.
   **/
  public get required(): boolean { return this.group.hasValidator(Validators.required); }

  constructor(
    @Inject(FORM_QUESTION_CONFIG_TOKEN) public readonly config: FormQuestionConfiguration,
    public readonly errorFormatter: ErrorFormatterService
  ) { }

  public ngAfterViewInit(): void {
    this.children.forEach(child => child.formGuideRequested.subscribe(() => this.requestFormGuide()));
  }

  public requestFormGuide(): void {
    this.formGuideRequested.emit();
  }
}