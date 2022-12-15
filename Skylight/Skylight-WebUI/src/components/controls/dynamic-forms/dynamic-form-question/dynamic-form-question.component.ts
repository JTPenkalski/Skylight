import { Directive, Input, ViewContainerRef } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { Question } from '../../../../services/dynamic-forms/questions/question';

@Directive()
export abstract class DynamicFormQuestionComponent<T extends Question = any> {
  @Input() public formGroup!: FormGroup;
  @Input() public question!: T;

  public get valid() { return this.formGroup.controls[this.question.key].valid; }
}

@Directive({
  selector: '[dynamicQuestion]',
})
export class DynamicFormQuestionDirective {
  public get viewContainer(): ViewContainerRef { return this._viewContainer; }

  constructor(private _viewContainer: ViewContainerRef) { }
}
