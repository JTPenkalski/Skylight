import { Injectable } from '@angular/core';

import { BaseMapper } from './index';
import { WeatherEventStatistics } from 'core/models';
import { IWeatherEventStatisticsFormModel } from 'form/form-models';

@Injectable()
export class WeatherEventStatisticsMapper extends BaseMapper<WeatherEventStatistics, IWeatherEventStatisticsFormModel> {
  public toPresentationModel(formModel: IWeatherEventStatisticsFormModel): WeatherEventStatistics {
    return new WeatherEventStatistics(
      0,
      formModel.damageCost.value,
      formModel.fatalities.value,
      formModel.efRating.value,
      formModel.pathDistance.value,
      formModel.funnelWidth.value,
      formModel.saffirSimpsonRating.value,
      formModel.lowestPressure.value,
      formModel.maxWindSpeed.value,
      formModel.richterMagnitude.value,
      formModel.mercalliIntensity.value,
      formModel.aftershocks.value,
      formModel.fault.value,
      formModel.relatedTsunami.value
    );
  }

  public toFormModel(presentationModel?: WeatherEventStatistics): IWeatherEventStatisticsFormModel {
    return {
      damageCost: this.formBuilder.nonNullable.control(presentationModel?.damageCost ?? 0),
      fatalities: this.formBuilder.nonNullable.control(presentationModel?.fatalities ?? 0),
      efRating: this.formBuilder.nonNullable.control(presentationModel?.efRating ?? ''),
      pathDistance: this.formBuilder.nonNullable.control(presentationModel?.pathDistance ?? 0),
      funnelWidth: this.formBuilder.nonNullable.control(presentationModel?.funnelWidth ?? 0),
      saffirSimpsonRating: this.formBuilder.nonNullable.control(presentationModel?.saffirSimpsonRating ?? ''),
      lowestPressure: this.formBuilder.nonNullable.control(presentationModel?.lowestPressure ?? 0),
      maxWindSpeed: this.formBuilder.nonNullable.control(presentationModel?.maxWindSpeed ?? 0),
      richterMagnitude: this.formBuilder.nonNullable.control(presentationModel?.richterMagnitude ?? 0),
      mercalliIntensity: this.formBuilder.nonNullable.control(presentationModel?.mercalliIntensity ?? 0),
      aftershocks: this.formBuilder.nonNullable.control(presentationModel?.aftershocks ?? 0),
      fault: this.formBuilder.nonNullable.control(presentationModel?.fault ?? ''),
      relatedTsunami: this.formBuilder.nonNullable.control(presentationModel?.relatedTsunami ?? false)
    };
  }
}
