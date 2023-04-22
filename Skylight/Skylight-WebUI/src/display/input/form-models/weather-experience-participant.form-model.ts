import { FormControl } from '@angular/forms';

import { WeatherEventObservationMethod } from 'presentation/models';
import { IBaseFormModel, IStormTrackerFormModel } from './index';

export interface IWeatherExperienceParticipantFormModel extends IBaseFormModel {
  readonly tracker: FormControl<IStormTrackerFormModel>;
  readonly observationMethod: FormControl<WeatherEventObservationMethod>;
}
