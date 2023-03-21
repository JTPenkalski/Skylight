import { Component } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';

import { ILocationFormModel } from 'display/input/form-models';
import { SkylightFormQuestionComponent } from '../skylight-form-question.component';

@Component({
  selector: 'skylight-form-question-location[instance]',
  templateUrl: './skylight-form-question-location.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-location.component.scss']
})
export class SkylightFormQuestionLocationComponent extends SkylightFormQuestionComponent {
  public get location(): FormGroup<ILocationFormModel> { return this.control as FormGroup<ILocationFormModel>; }
}
