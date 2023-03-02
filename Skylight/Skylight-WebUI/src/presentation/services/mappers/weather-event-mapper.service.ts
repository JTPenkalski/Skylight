import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { BaseMapper, LocationMapper, WeatherEventAlertMapper, WeatherEventStatisticsMapper, WeatherExperienceMapper, WeatherMapper } from './index';
import { Weather, WeatherEvent, WeatherExperience } from 'core/models';
import { IWeatherEventFormModel } from 'form/form-models';
import { IWeatherEventWebModel } from 'communication/web-models';

@Injectable()
export class WeatherEventMapper extends BaseMapper<IWeatherEventWebModel, WeatherEvent, IWeatherEventFormModel> {
  constructor(
    formBuilder: FormBuilder,
    protected readonly weatherMapper: WeatherMapper,
    protected readonly weatherExperienceMapper: WeatherExperienceMapper,
    protected readonly locationMapper: LocationMapper,
    protected readonly weatherEventAlertMapper: WeatherEventAlertMapper,
    protected readonly weatherEventStatisticsMapper: WeatherEventStatisticsMapper
  ) {
    super(formBuilder);
  }

  public toWebModel(presentationModel: WeatherEvent): IWeatherEventWebModel
  {
    return {
      id: presentationModel.id,
      name: presentationModel.name,
      description: presentationModel.description,
      weather: this.weatherMapper.toWebModel(presentationModel.weather),
      startDate: presentationModel.startDate,
      endDate: presentationModel.endDate,
      weatherExperience: this.weatherExperienceMapper.toWebModel(presentationModel.experience),
      locations: presentationModel.locations.map(l => this.locationMapper.toWebModel(l)),
      alerts: presentationModel.alerts.map(a => this.weatherEventAlertMapper.toWebModel(a)),
      statistics: this.weatherEventStatisticsMapper.toWebModel(presentationModel.statistics)
    };
  }

  public toPresentationModel(formModel: IWeatherEventFormModel): WeatherEvent {
    return new WeatherEvent(
      formModel.name.value,
      formModel.description.value,
      formModel.weather.value,
      formModel.startDate.value,
      this.weatherEventStatisticsMapper.toPresentationModel(formModel.statistics.controls),
      formModel.weatherExperience.value,
      formModel.locations.controls.map(l => this.locationMapper.toPresentationModel(l.controls)),
      formModel.alerts.controls.map(a => this.weatherEventAlertMapper.toPresentationModel(a.controls)),
      formModel.endDate?.value ?? undefined
    );
  }

  public toFormModel(presentationModel: WeatherEvent): IWeatherEventFormModel {
    return {
      name: this.formBuilder.nonNullable.control(presentationModel?.name ?? '', Validators.required),
      description: this.formBuilder.nonNullable.control(presentationModel?.description ?? ''),
      weather: this.formBuilder.nonNullable.control(new Weather(), Validators.required),
      startDate: this.formBuilder.nonNullable.control(presentationModel?.startDate ?? new Date(), Validators.required),
      endDate: this.formBuilder.control(presentationModel?.endDate ?? null),
      weatherExperience: this.formBuilder.nonNullable.control(new WeatherExperience(), Validators.required),
      locations: this.formBuilder.nonNullable.array(presentationModel?.locations.map(l => this.formBuilder.group(this.locationMapper.toFormModel(l))) ?? []),
      alerts: this.formBuilder.nonNullable.array(presentationModel?.alerts.map(a => this.formBuilder.group(this.weatherEventAlertMapper.toFormModel(a))) ?? []),
      statistics: this.formBuilder.nonNullable.group(this.weatherEventStatisticsMapper.toFormModel(presentationModel.statistics))
    };
  }
}
