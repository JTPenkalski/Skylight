import { Injectable } from '@angular/core';

import { BaseMapper } from 'presentation/services/mappers';
import { WeatherEventStatistics } from 'core/models';
import { IWeatherEventStatisticsFormModel } from 'form/form-models';
import { IWeatherEventStatisticsWebModel } from 'communication/web-models';

@Injectable()
export class WeatherEventStatisticsMapper extends BaseMapper<IWeatherEventStatisticsWebModel, WeatherEventStatistics, IWeatherEventStatisticsFormModel> {
  public toWebModel(presentationModel: WeatherEventStatistics): IWeatherEventStatisticsWebModel
  {
    return {
      id: presentationModel.id,
      damageCost: presentationModel.damageCost ?? undefined,
      fatalities: presentationModel.fatalities ?? undefined,
      efRating: presentationModel.efRating ?? undefined,
      pathDistance: presentationModel.pathDistance ?? undefined,
      funnelWidth: presentationModel.funnelWidth ?? undefined,
      saffirSimpsonRating: presentationModel.saffirSimpsonRating ?? undefined,
      lowestPressure: presentationModel.lowestPressure ?? undefined,
      maxWindSpeed: presentationModel.maxWindSpeed ?? undefined,
      richterMagnitude: presentationModel.richterMagnitude ?? undefined,
      mercalliIntensity: presentationModel.mercalliIntensity ?? undefined,
      aftershocks: presentationModel.aftershocks ?? undefined,
      fault: presentationModel.fault ?? undefined,
      relatedTsunami: presentationModel.relatedTsunami ?? undefined
    };
  }

  public toPresentationModel(formModel: IWeatherEventStatisticsFormModel): WeatherEventStatistics {
    return new WeatherEventStatistics(
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

  public toFormModel(presentationModel: WeatherEventStatistics): IWeatherEventStatisticsFormModel {
    return {
      damageCost: this.formBuilder.control(presentationModel.damageCost),
      fatalities: this.formBuilder.control(presentationModel.fatalities),
      efRating: this.formBuilder.control(presentationModel.efRating ),
      pathDistance: this.formBuilder.control(presentationModel.pathDistance),
      funnelWidth: this.formBuilder.control(presentationModel.funnelWidth),
      saffirSimpsonRating: this.formBuilder.control(presentationModel.saffirSimpsonRating ),
      lowestPressure: this.formBuilder.control(presentationModel.lowestPressure),
      maxWindSpeed: this.formBuilder.control(presentationModel.maxWindSpeed),
      richterMagnitude: this.formBuilder.control(presentationModel.richterMagnitude),
      mercalliIntensity: this.formBuilder.control(presentationModel.mercalliIntensity),
      aftershocks: this.formBuilder.control(presentationModel.aftershocks),
      fault: this.formBuilder.control(presentationModel.fault),
      relatedTsunami: this.formBuilder.control(presentationModel.relatedTsunami)
    };
  }
}
