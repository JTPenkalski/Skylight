import { KeyValue } from '@angular/common';
import { Type } from '@angular/core';

import { DropdownQuestionComponent } from '../../../components/controls/dynamic-forms/dropdown-question/dropdown-question.component';
import { DynamicFormQuestionComponent } from '../../../components/controls/dynamic-forms/dynamic-form-question/dynamic-form-question.component';
import { Question, QuestionConfig } from './question';

export interface DropdownQuestionConfig<T> extends QuestionConfig<T> {
  options: KeyValue<string, string>[];
}

export class DropdownQuestion extends Question<string> {
  protected _options: KeyValue<string, string>[];
  public get options(): KeyValue<string, string>[] { return this._options; }

  public override get dynamicComponent(): Type<DynamicFormQuestionComponent<DropdownQuestion>> { return DropdownQuestionComponent; }

  constructor(config: DropdownQuestionConfig<string>) {
    super(config);

    this._options = config.options;
  }
}
