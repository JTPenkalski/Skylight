import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { BaseFormMapper, LocationFormMapper, WeatherEventAlertFormMapper, WeatherEventStatisticsFormMapper, WeatherExperienceFormMapper, WeatherFormMapper } from './index';
import { Weather, WeatherAlert, WeatherEvent, WeatherExperience } from 'core/models';
import { IWeatherEventFormModel } from 'display/input/form-models';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventFormMapper extends BaseFormMapper<WeatherEvent, IWeatherEventFormModel> {
  constructor(
    formBuilder: FormBuilder,
    protected readonly weatherMapper: WeatherFormMapper,
    protected readonly weatherExperienceMapper: WeatherExperienceFormMapper,
    protected readonly locationMapper: LocationFormMapper,
    protected readonly weatherEventAlertMapper: WeatherEventAlertFormMapper,
    protected readonly weatherEventStatisticsMapper: WeatherEventStatisticsFormMapper
  ) {
    super(formBuilder);
  }

  public toPresentationModel(source: IWeatherEventFormModel): WeatherEvent {
    return new WeatherEvent(
      source.name.value,
      source.description.value,
      source.weather.value,
      source.startDate.value,
      this.weatherEventStatisticsMapper.toPresentationModel(source.statistics.controls),
      source.experience.value,
      source.locations.controls.map(l => this.locationMapper.toPresentationModel(l.controls)),
      source.alerts.controls.map(a => this.weatherEventAlertMapper.toPresentationModel(a.controls)),
      source.endDate?.value ?? undefined
    );
  }

  public toDisplayModel(source: WeatherEvent): IWeatherEventFormModel {
    return {
      name: this.formBuilder.nonNullable.control(source.name, Validators.required),
      description: this.formBuilder.nonNullable.control(source.description),
      weather: this.formBuilder.nonNullable.control(source.weather, Validators.required),
      startDate: this.formBuilder.nonNullable.control(source.startDate, Validators.required),
      endDate: this.formBuilder.control(source.endDate ?? null),
      experience: this.formBuilder.nonNullable.control(source.experience, Validators.required),
      locations: this.formBuilder.nonNullable.array(source.locations.map(l => this.formBuilder.group(this.locationMapper.toDisplayModel(l)))),
      alerts: this.formBuilder.nonNullable.array(source.alerts.map(a => this.formBuilder.group(this.weatherEventAlertMapper.toDisplayModel(a)))),
      statistics: this.formBuilder.nonNullable.group(this.weatherEventStatisticsMapper.toDisplayModel(source.statistics))
    };
  }
}
