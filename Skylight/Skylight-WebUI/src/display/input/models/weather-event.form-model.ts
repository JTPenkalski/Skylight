import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import {
  BaseModel, IBaseModel,
  WeatherEventLocation, IWeatherEventLocation,
  WeatherEventAlert, IWeatherEventAlert,
  WeatherEventStatistics, IWeatherEventStatistics
} from './index';
import {
  WeatherEvent as WeatherEventCoreModel, IWeatherEvent as IWeatherEventCoreModel,
  IWeather as IWeatherCoreModel,
  IWeatherExperience as IWeatherExperienceCoreModel
} from 'presentation/models';

export interface IWeatherEvent extends IBaseModel {
  readonly name: FormControl<string>;
  readonly weather: FormControl<IWeatherCoreModel>;
  readonly startDate: FormControl<Date>;
  readonly experience: FormControl<IWeatherExperienceCoreModel>;
  readonly locations: FormArray<FormGroup<IWeatherEventLocation>>;
  readonly alerts: FormArray<FormGroup<IWeatherEventAlert>>;
  readonly statistics: FormGroup<IWeatherEventStatistics>;
  readonly description: FormControl<string | null>;
  readonly endDate: FormControl<Date | null>;
}

export class WeatherEvent extends BaseModel implements IWeatherEvent {
  public readonly name: FormControl<string>;
  public readonly weather: FormControl<IWeatherCoreModel>;
  public readonly startDate: FormControl<Date>;
  public readonly experience: FormControl<IWeatherExperienceCoreModel>;
  public readonly locations: FormArray<FormGroup<IWeatherEventLocation>>;
  public readonly alerts: FormArray<FormGroup<IWeatherEventAlert>>;
  public readonly statistics: FormGroup<IWeatherEventStatistics>;
  public readonly description: FormControl<string | null>;
  public readonly endDate: FormControl<Date | null>;

  constructor(formBuilder: FormBuilder, data?: IWeatherEventCoreModel) {
    super();

    data ??= new WeatherEventCoreModel();

    this.name = formBuilder.nonNullable.control(data.name, Validators.required);
    this.weather = formBuilder.nonNullable.control(data.weather, Validators.required);
    this.startDate = formBuilder.nonNullable.control(data.startDate, Validators.required);
    this.experience = formBuilder.nonNullable.control(data.experience, Validators.required);
    this.locations = formBuilder.nonNullable.array(data.locations.map(l => formBuilder.group(new WeatherEventLocation(formBuilder, l))));
    this.alerts = formBuilder.nonNullable.array(data.alerts.map(a => formBuilder.group(new WeatherEventAlert(formBuilder, a))));
    this.statistics = formBuilder.nonNullable.group(new WeatherEventStatistics(formBuilder, data.statistics));
    this.description = formBuilder.nonNullable.control(data.description ?? null);
    this.endDate = formBuilder.control(data.endDate ?? null);
  }
}
