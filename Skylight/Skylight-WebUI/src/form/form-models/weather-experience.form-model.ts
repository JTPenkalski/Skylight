import { FormArray, FormControl } from '@angular/forms';

import { IBaseFormModel, IWeatherEventFormModel, IWeatherExperienceParticipantFormModel } from "./index";

export interface IWeatherExperienceFormModel extends IBaseFormModel {
  readonly name: FormControl<string>;
  readonly description: FormControl<string>;
  readonly startTime: FormControl<Date>;
  readonly endTime: FormControl<Date>;
  readonly participants: FormControl<IWeatherExperienceParticipantFormModel[]>;
  readonly events: FormArray<FormControl<IWeatherEventFormModel>>;
}
