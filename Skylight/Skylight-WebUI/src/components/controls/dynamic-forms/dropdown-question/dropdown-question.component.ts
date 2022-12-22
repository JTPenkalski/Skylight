import { Component } from '@angular/core';

import { DropdownQuestion } from 'src/services/dynamic-forms/questions/dropdown-question';
import { DynamicFormQuestionComponent } from '../dynamic-form-question/dynamic-form-question.component';

@Component({
  selector: 'dynamic-dropdown-question',
  templateUrl: './dropdown-question.component.html',
  styleUrls: ['./dropdown-question.component.scss']
})
export class DropdownQuestionComponent extends DynamicFormQuestionComponent<DropdownQuestion> {

}
