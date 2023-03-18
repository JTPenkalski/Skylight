import { Injectable } from '@angular/core';

import { WeatherEvent } from 'core/models';
import { WeatherEventWebModel } from 'web/web-models';
import { BaseWebMapper, LocationWebMapper, WeatherEventAlertWebMapper, WeatherEventStatisticsWebMapper, WeatherExperienceWebMapper, WeatherWebMapper } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventWebMapper extends BaseWebMapper<WeatherEvent, WeatherEventWebModel> {
  constructor(
    protected readonly weatherMapper: WeatherWebMapper,
    protected readonly weatherEventStatisticsMapper: WeatherEventStatisticsWebMapper,
    protected readonly weatherExperienceMapper: WeatherExperienceWebMapper,
    protected readonly locationsMapper: LocationWebMapper,
    protected readonly weatherEventAlertsMapper: WeatherEventAlertWebMapper
  ) {
    super();
  }

  public toPresentationModel(source: WeatherEventWebModel): WeatherEvent
  {
    return new WeatherEvent(
      source.name,
      source.description,
      this.weatherMapper.toPresentationModel(source.weather),
      source.startDate,
      this.weatherEventStatisticsMapper.toPresentationModel(source.statistics),
      this.weatherExperienceMapper.toPresentationModel(source.experience),
      source.locations.map(l => this.locationsMapper.toPresentationModel(l)),
      source.alerts.map(a => this.weatherEventAlertsMapper.toPresentationModel(a)),
      source.endDate,
      source.id
    );
  }

  public toWebModel(source: WeatherEvent): WeatherEventWebModel
  {
    return new WeatherEventWebModel(
      source.id,
      source.name,
      source.description,
      this.weatherMapper.toWebModel(source.weather),
      source.startDate,
      this.weatherEventStatisticsMapper.toWebModel(source.statistics),
      this.weatherExperienceMapper.toWebModel(source.experience),
      source.locations.map(l => this.locationsMapper.toWebModel(l)),
      source.alerts.map(a => this.weatherEventAlertsMapper.toWebModel(a)),
      source.endDate
    );
  }
}
