import { KeyValue } from '@angular/common';
import { Type } from '@angular/core';

import { DropdownQuestionComponent } from '../../../components/controls/dynamic-forms/dropdown-question/dropdown-question.component';
import { DynamicFormQuestionComponent } from '../../../components/controls/dynamic-forms/dynamic-form-question/dynamic-form-question.component';
import { QuestionValidator } from '../validators/question-validator';
import { Question, QuestionConfig } from './question';

/**
 * Represents a Dropdown Question model to use when creating Dynamic Forms.
 * The properties here are used to generate an equivalent FormControl in the corresponding component.
 * This class will create a Dropdown control that uses manually specified options in the XML.
 **/
export class DropdownQuestion extends Question<string> {
  protected _options: DropdownQuestionOptions;
  public get options(): DropdownQuestionOptions { return this._options; }

  public override get dynamicComponent(): Type<DynamicFormQuestionComponent<DropdownQuestion>> { return DropdownQuestionComponent; }

  constructor(options: DropdownQuestionOptions, config: QuestionConfig<string>, validators?: QuestionValidator[]) {
    super(config, validators);

    this._options = options;
  }
}

/**
 * The set of options to use for a Dropdown control.
 * If a value is not specified in the XML, the text will be used by default (see the service file).
 **/
export class DropdownQuestionOptions {
  protected _allOptions: KeyValue<string, string>[];
  public get allOptions(): KeyValue<string, string>[] { return this._allOptions; } 

  protected map: { [key: string]: string };

  constructor(options: KeyValue<string, string>[]) {
    this._allOptions = options;
    this.map = options.reduce((accumulator, keyValuePair) => {
      return {
        ...accumulator,
        [keyValuePair.key]: keyValuePair.value
      };
    }, {});
  }

  public option(optionKey: string): string { return this.map[optionKey]; }
}
