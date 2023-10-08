import { Component } from '@angular/core';

import { SkylightFormQuestionComponent } from '../skylight-form-question.component';

@Component({
  selector: 'skylight-form-question-input[control]',
  templateUrl: './skylight-form-question-input.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-input.component.scss'],
  providers: [{ provide: SkylightFormQuestionComponent, useExisting: SkylightFormQuestionInputComponent }]
})
export class SkylightFormQuestionInputComponent extends SkylightFormQuestionComponent {

}
