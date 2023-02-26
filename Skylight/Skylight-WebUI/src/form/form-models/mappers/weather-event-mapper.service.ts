import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { BaseMapper, LocationMapper, WeatherEventAlertMapper, WeatherEventStatisticsMapper } from './index';
import { Weather, WeatherEvent, WeatherExperience } from 'core/models';
import { IWeatherEventFormModel } from 'form/form-models';

@Injectable()
export class WeatherEventMapper extends BaseMapper<WeatherEvent, IWeatherEventFormModel> {
  constructor(
    formBuilder: FormBuilder,
    protected readonly locationMapper: LocationMapper,
    protected readonly weatherEventAlertMapper: WeatherEventAlertMapper,
    protected readonly weatherEventStatisticsMapper: WeatherEventStatisticsMapper) {
    super(formBuilder);
  }

  public toPresentationModel(formModel: IWeatherEventFormModel): WeatherEvent {
    return new WeatherEvent(
      0,
      formModel.name.value,
      formModel.description.value,
      formModel.weather.value,
      formModel.startDate.value,
      formModel.endDate.value,
      this.weatherEventStatisticsMapper.toPresentationModel(formModel.statistics.value),
      formModel.weatherExperience.value,
      formModel.locations.value.map(l => this.locationMapper.toPresentationModel(l)),
      formModel.alerts.value.map(a => this.weatherEventAlertMapper.toPresentationModel(a))
    );
  }

  public toFormModel(presentationModel?: WeatherEvent): IWeatherEventFormModel {
    return {
      name: this.formBuilder.nonNullable.control(presentationModel?.name ?? '', Validators.required),
      description: this.formBuilder.nonNullable.control(presentationModel?.description ?? ''),
      weather: this.formBuilder.nonNullable.control(new Weather(), Validators.required),
      startDate: this.formBuilder.nonNullable.control(presentationModel?.startDate ?? new Date(), Validators.required),
      endDate: this.formBuilder.control(presentationModel?.endDate ?? null),
      weatherExperience: this.formBuilder.nonNullable.control(new WeatherExperience(), Validators.required),
      locations: this.formBuilder.nonNullable.array(presentationModel?.locations.map(l => this.locationMapper.toFormModel(l)) ?? []),
      alerts: this.formBuilder.nonNullable.array(presentationModel?.alerts.map(a => this.weatherEventAlertMapper.toFormModel(a)) ?? []),
      statistics: this.formBuilder.nonNullable.control(this.weatherEventStatisticsMapper.toFormModel())
    };
  }
}
