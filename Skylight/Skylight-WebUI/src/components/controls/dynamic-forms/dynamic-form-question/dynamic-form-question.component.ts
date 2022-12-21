import { Directive, Input,  ViewContainerRef } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import { Section } from 'src/services/dynamic-forms/sections/section';
import { Question } from 'src/services/dynamic-forms/questions/question';

@Directive()
export abstract class DynamicFormQuestionComponent<T extends Question = any> {
  @Input() public question!: T;
  @Input() public section!: Section;
  @Input() public model!: FormGroup;

  public get control(): FormControl { return this.model.get([this.section.id, this.question.id].join('.')) as FormControl; }
}

@Directive({
  selector: '[dynamicQuestion]',
})
export class DynamicFormQuestionDirective {
  public get viewContainer(): ViewContainerRef { return this._viewContainer; }

  constructor(private _viewContainer: ViewContainerRef) { }
}
