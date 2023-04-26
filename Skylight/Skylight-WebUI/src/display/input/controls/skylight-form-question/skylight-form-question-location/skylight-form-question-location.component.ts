import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { ILocation } from 'display/input/models';
import { SkylightFormQuestionComponent } from '../skylight-form-question.component';

/**
 * Form Field group for the Location model.
 * @requires [group]: The FormGroup this component is linked to.
 **/
@Component({
  selector: 'skylight-form-question-location[group]',
  templateUrl: './skylight-form-question-location.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-location.component.scss']
})
export class SkylightFormQuestionLocationComponent extends SkylightFormQuestionComponent {
  @Input() public group!: FormGroup<ILocation>;
}
