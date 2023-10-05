import { Component } from '@angular/core';

import { SkylightFormQuestionContainerComponent } from '../skylight-form-question-container.component';
import { IWeatherEventLocation } from 'display/input/models';
import { WeatherEventLocationFormGuide } from 'web/models';

/**
 * Form Field group for the Location model.
 * @requires [group]: The FormGroup this component is linked to.
 **/
@Component({
  selector: 'skylight-form-question-weather-event-location[group]',
  templateUrl: './skylight-form-question-weather-event-location.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-weather-event-location.component.scss']
})
export class SkylightFormQuestionWeatherEventLocationComponent extends SkylightFormQuestionContainerComponent<IWeatherEventLocation, WeatherEventLocationFormGuide> {

}
