import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { ISkylightFormQuestionContainer } from '../types';
import { ILocation } from 'display/input/models';

/**
 * Form Field group for the Location model.
 * @requires [group]: The FormGroup this component is linked to.
 **/
@Component({
  selector: 'skylight-form-question-location[group]',
  templateUrl: './skylight-form-question-location.component.html',
  styleUrls: ['./skylight-form-question-location.component.scss']
})
export class SkylightFormQuestionLocationComponent implements ISkylightFormQuestionContainer {
  @Input() public label: string = '';
  @Input() public group!: FormGroup<ILocation>;
}
