import { Type } from '@angular/core';

import { DynamicFormQuestionComponent } from 'src/components/controls/dynamic-forms/dynamic-form-question/dynamic-form-question.component';
import { TextboxQuestionComponent } from 'src/components/controls/dynamic-forms/textbox-question/textbox-question.component';
import { QuestionValidator } from '../validators/question-validator';
import { Question, QuestionConfig } from './question';

/**
 * Represents a Textbox Question model to use when creating Dynamic Forms.
 * The properties here are used to generate an equivalent FormControl in the corresponding component.
 * This class will create a Textbox control that uses manually specified options in the XML.
 **/
export class TextboxQuestion extends Question<string> {
  public override get dynamicComponent(): Type<DynamicFormQuestionComponent<TextboxQuestion>> { return TextboxQuestionComponent; }

  constructor(config: QuestionConfig<string>, validators?: QuestionValidator[]) {
    super(config, validators);
  }
}
