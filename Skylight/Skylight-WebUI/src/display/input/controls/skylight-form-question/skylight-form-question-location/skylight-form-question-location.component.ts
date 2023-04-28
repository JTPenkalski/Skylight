import { Component } from '@angular/core';

import { SkylightFormQuestionContainerComponent } from '../skylight-form-question-container.component';
import { ILocation } from 'display/input/models';

/**
 * Form Field group for the Location model.
 * @requires [group]: The FormGroup this component is linked to.
 **/
@Component({
  selector: 'skylight-form-question-location[group]',
  templateUrl: './skylight-form-question-location.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-location.component.scss']
})
export class SkylightFormQuestionLocationComponent extends SkylightFormQuestionContainerComponent<ILocation> {

}
