import { Component } from '@angular/core';

import { SkylightFormQuestionComponent } from '../skylight-form-question.component';

@Component({
  selector: 'skylight-form-question-textarea[control]',
  templateUrl: './skylight-form-question-textarea.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-textarea.component.scss'],
  providers: [{ provide: SkylightFormQuestionComponent, useExisting: SkylightFormQuestionTextAreaComponent }]
})
export class SkylightFormQuestionTextAreaComponent extends SkylightFormQuestionComponent {

}
