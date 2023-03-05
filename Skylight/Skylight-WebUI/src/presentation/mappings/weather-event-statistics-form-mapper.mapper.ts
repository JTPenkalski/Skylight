import { Injectable } from '@angular/core';

import { BaseFormMapper } from 'presentation/mappings';
import { WeatherEventStatistics } from 'core/models';
import { IWeatherEventStatisticsFormModel } from 'display/input/form-models';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventStatisticsFormMapper extends BaseFormMapper<WeatherEventStatistics, IWeatherEventStatisticsFormModel> {
  public toPresentationModel(source: IWeatherEventStatisticsFormModel): WeatherEventStatistics {
    return new WeatherEventStatistics(
      source.damageCost.value,
      source.fatalities.value,
      source.efRating.value,
      source.pathDistance.value,
      source.funnelWidth.value,
      source.saffirSimpsonRating.value,
      source.lowestPressure.value,
      source.maxWindSpeed.value,
      source.richterMagnitude.value,
      source.mercalliIntensity.value,
      source.aftershocks.value,
      source.fault.value,
      source.relatedTsunami.value
    );
  }

  public toDisplayModel(source: WeatherEventStatistics): IWeatherEventStatisticsFormModel {
    return {
      damageCost: this.formBuilder.control(source.damageCost),
      fatalities: this.formBuilder.control(source.fatalities),
      efRating: this.formBuilder.control(source.efRating ),
      pathDistance: this.formBuilder.control(source.pathDistance),
      funnelWidth: this.formBuilder.control(source.funnelWidth),
      saffirSimpsonRating: this.formBuilder.control(source.saffirSimpsonRating ),
      lowestPressure: this.formBuilder.control(source.lowestPressure),
      maxWindSpeed: this.formBuilder.control(source.maxWindSpeed),
      richterMagnitude: this.formBuilder.control(source.richterMagnitude),
      mercalliIntensity: this.formBuilder.control(source.mercalliIntensity),
      aftershocks: this.formBuilder.control(source.aftershocks),
      fault: this.formBuilder.control(source.fault),
      relatedTsunami: this.formBuilder.control(source.relatedTsunami)
    };
  }
}
