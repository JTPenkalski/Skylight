import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import {
  BaseModel, IBaseModel,
  Location, ILocation
} from './index';
import {
  WeatherEventLocation as WeatherEventLocationCoreModel, IWeatherEventLocation as IWeatherEventLocationCoreModel
} from 'presentation/models';

export interface IWeatherEventLocation extends IBaseModel {
  readonly startTime: FormControl<Date>;
  readonly endTime: FormControl<Date>;
  readonly location: FormGroup<ILocation>;
}

export class WeatherEventLocation extends BaseModel implements IWeatherEventLocation {
  public readonly startTime: FormControl<Date>;
  public readonly endTime: FormControl<Date>;
  public readonly location: FormGroup<ILocation>;

  constructor(formBuilder: FormBuilder, data?: IWeatherEventLocationCoreModel) {
    super();

    data ??= new WeatherEventLocationCoreModel();

    this.startTime = formBuilder.nonNullable.control(data.startTime, Validators.required);
    this.endTime = formBuilder.nonNullable.control(data.endTime, Validators.required);
    this.location = formBuilder.nonNullable.group(new Location(formBuilder, data.location));
  }
}
