import { Component } from '@angular/core';

import { SkylightFormQuestionContainerComponent } from '../skylight-form-question-container.component';
import { IWeatherEventStatistics } from 'display/input/models';
import { ISelectOption } from '../types';
import { WeatherEventStatisticsFormGuide } from 'web/models';

/**
 * Form Field group for the Weather Event Statistics model.
 * @requires [group]: The FormGroup this component is linked to.
 **/
@Component({
  selector: 'skylight-form-question-weather-event-statistics[group]',
  templateUrl: './skylight-form-question-weather-event-statistics.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-weather-event-statistics.component.scss']
})
export class SkylightFormQuestionWeatherEventStatisticsComponent extends SkylightFormQuestionContainerComponent<IWeatherEventStatistics, WeatherEventStatisticsFormGuide> {
  public get showTornadoSection(): boolean {
    return ![
      this.guide?.efRating,
      this.guide?.funnelWidth,
      this.guide?.pathDistance
    ].every(x => x?.hidden);
  }

  public get showHurricaneSection(): boolean {
    return ![
      this.guide?.saffirSimpsonRating,
      this.guide?.lowestPressure,
      this.guide?.maxWindSpeed
    ].every(x => x?.hidden);
  }

  public get showEarthquakeSection(): boolean {
    return ![
      this.guide?.richterMagnitude,
      this.guide?.mercalliIntensity,
      this.guide?.aftershocks,
      this.guide?.fault,
      this.guide?.relatedTsunami
    ].every(x => x?.hidden);
  }
}
