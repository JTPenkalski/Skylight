import { FormControl } from '@angular/forms';

import { WeatherEventObservationMethod } from 'core/models';
import { IBaseFormModel, IStormTrackerFormModel } from './index';

export interface IWeatherExperienceParticipantFormModel extends IBaseFormModel {
  readonly tracker: FormControl<IStormTrackerFormModel>;
  readonly observationMethod: FormControl<WeatherEventObservationMethod>;
}
