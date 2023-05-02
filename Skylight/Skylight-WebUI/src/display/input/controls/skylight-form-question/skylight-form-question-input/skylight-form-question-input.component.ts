import { Component } from '@angular/core';

import { SkylightFormQuestionComponent } from '../skylight-form-question.component';
import { zipCodeValidator } from 'display/input/validators';

@Component({
  selector: 'skylight-form-question-input[control]',
  templateUrl: './skylight-form-question-input.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-input.component.scss']
})
export class SkylightFormQuestionInputComponent extends SkylightFormQuestionComponent {
  /**
   * Indicates if this AbstractControl has the Zip Code validator.
   **/
  public get zipCode(): boolean { return this.control.hasValidator(zipCodeValidator); }
}
