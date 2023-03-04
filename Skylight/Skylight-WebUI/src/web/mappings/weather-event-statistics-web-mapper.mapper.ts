import { Injectable } from '@angular/core';

import { WeatherEventStatistics } from 'core/models';
import { WeatherEventStatisticsWebModel } from 'web/web-models';
import { BaseWebMapper } from './index';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventStatisticsWebMapper extends BaseWebMapper<WeatherEventStatistics, WeatherEventStatisticsWebModel> {
  public toPresentationModel(source: WeatherEventStatisticsWebModel): WeatherEventStatistics
  {
    return new WeatherEventStatistics(
      source.damageCost,
      source.fatalities,
      source.efRating,
      source.pathDistance,
      source.funnelWidth,
      source.saffirSimpsonRating,
      source.lowestPressure,
      source.maxWindSpeed,
      source.richterMagnitude,
      source.mercalliIntensity,
      source.aftershocks,
      source.fault,
      source.relatedTsunami,
      source.id
    );
  }

  public toWebModel(source: WeatherEventStatistics): WeatherEventStatisticsWebModel
  {
    return new WeatherEventStatisticsWebModel(
      source.id,
      source.damageCost ?? undefined,
      source.fatalities ?? undefined,
      source.efRating ?? undefined,
      source.pathDistance ?? undefined,
      source.funnelWidth ?? undefined,
      source.saffirSimpsonRating ?? undefined,
      source.lowestPressure ?? undefined,
      source.maxWindSpeed ?? undefined,
      source.richterMagnitude ?? undefined,
      source.mercalliIntensity ?? undefined,
      source.aftershocks ?? undefined,
      source.fault ?? undefined,
      source.relatedTsunami ?? undefined
    );
  }
}
