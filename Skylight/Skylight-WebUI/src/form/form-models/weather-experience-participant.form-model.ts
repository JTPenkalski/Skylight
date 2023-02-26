import { FormControl } from '@angular/forms';

import { WeatherEventObservationMethod } from 'core/models';
import { IBaseFormModel, IStormTrackerFormModel, IWeatherExperienceFormModel } from "./index";

export interface IWeatherExperienceParticipantFormModel extends IBaseFormModel {
  readonly experience: FormControl<IWeatherExperienceFormModel>;
  readonly tracker: FormControl<IStormTrackerFormModel>;
  readonly observationMethod: FormControl<WeatherEventObservationMethod>;
}
