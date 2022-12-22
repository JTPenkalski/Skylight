import { Component } from '@angular/core';

import { TextboxQuestion } from 'src/services/dynamic-forms/questions/textbox-question';
import { DynamicFormQuestionComponent } from '../dynamic-form-question/dynamic-form-question.component';

@Component({
  selector: 'dynamic-textbox-question',
  templateUrl: './textbox-question.component.html',
  styleUrls: ['./textbox-question.component.scss']
})
export class TextboxQuestionComponent extends DynamicFormQuestionComponent<TextboxQuestion> {

}