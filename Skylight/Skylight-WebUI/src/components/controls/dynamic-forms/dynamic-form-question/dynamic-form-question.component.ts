import { Directive, Input,  ViewContainerRef } from '@angular/core';
import { ControlContainer, FormControl, FormGroup } from '@angular/forms';

import { Section } from '../../../../services/dynamic-forms/sections/section';
import { Question } from '../../../../services/dynamic-forms/questions/question';

@Directive()
export abstract class DynamicFormQuestionComponent<T extends Question = any> {
  @Input() public question!: T;
  @Input() public section!: Section;
  @Input() public formGroup!: FormGroup;

  public get group(): FormGroup { return this.parent.control as FormGroup; }
  public get control(): FormControl { return this.group.get(this.question.id) as FormControl; }

  constructor(protected parent: ControlContainer) { }
}

@Directive({
  selector: '[dynamicQuestion]',
})
export class DynamicFormQuestionDirective {
  public get viewContainer(): ViewContainerRef { return this._viewContainer; }

  constructor(private _viewContainer: ViewContainerRef) { }
}
