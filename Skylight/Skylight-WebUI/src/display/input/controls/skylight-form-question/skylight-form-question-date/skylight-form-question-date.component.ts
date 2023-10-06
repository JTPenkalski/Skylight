import { Component } from '@angular/core';

import { SkylightFormQuestionComponent } from '../skylight-form-question.component';

@Component({
  selector: 'skylight-form-question-date[control]',
  templateUrl: './skylight-form-question-date.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-date.component.scss'],
  providers: [{ provide: SkylightFormQuestionComponent, useExisting: SkylightFormQuestionDateComponent }]
})
export class SkylightFormQuestionDateComponent extends SkylightFormQuestionComponent {
  protected override implementGuide(): void {
    if (this.guide?.defaultValue) {
      this.control.setValue(new Date(this.guide?.defaultValue));
    }
  }
}
