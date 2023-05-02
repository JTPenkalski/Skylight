import { FormBuilder, FormControl } from '@angular/forms';

import { BaseModel, IBaseModel } from './index';
import {
  WeatherEventStatistics as WeatherEventStatisticsCoreModel, IWeatherEventStatistics as IWeatherEventStatisticsCoreModel
} from 'presentation/models';

export interface IWeatherEventStatistics extends IBaseModel {
  readonly damageCost: FormControl<number | null>;
  readonly fatalities: FormControl<number | null>;
  readonly efRating: FormControl<number | null>;
  readonly pathDistance: FormControl<number | null>;
  readonly funnelWidth: FormControl<number | null>;
  readonly saffirSimpsonRating: FormControl<number | null>;
  readonly lowestPressure: FormControl<number | null>;
  readonly maxWindSpeed: FormControl<number | null>;
  readonly richterMagnitude: FormControl<number | null>;
  readonly mercalliIntensity: FormControl<number | null>;
  readonly aftershocks: FormControl<number | null>;
  readonly fault: FormControl<string | null>;
  readonly relatedTsunami: FormControl<boolean | null>;
}

export class WeatherEventStatistics extends BaseModel implements IWeatherEventStatistics {
  public readonly damageCost: FormControl<number | null>;
  public readonly fatalities: FormControl<number | null>;
  public readonly efRating: FormControl<number | null>;
  public readonly pathDistance: FormControl<number | null>;
  public readonly funnelWidth: FormControl<number | null>;
  public readonly saffirSimpsonRating: FormControl<number | null>;
  public readonly lowestPressure: FormControl<number | null>;
  public readonly maxWindSpeed: FormControl<number | null>;
  public readonly richterMagnitude: FormControl<number | null>;
  public readonly mercalliIntensity: FormControl<number | null>;
  public readonly aftershocks: FormControl<number | null>;
  public readonly fault: FormControl<string | null>;
  public readonly relatedTsunami: FormControl<boolean | null>;

  constructor(formBuilder: FormBuilder, data?: IWeatherEventStatisticsCoreModel) {
    super();

    data ??= new WeatherEventStatisticsCoreModel();

    this.damageCost = formBuilder.control(data.damageCost ?? null),
    this.fatalities = formBuilder.control(data.fatalities ?? null),
    this.efRating = formBuilder.control(data.efRating  ?? null),
    this.pathDistance = formBuilder.control(data.pathDistance ?? null),
    this.funnelWidth = formBuilder.control(data.funnelWidth ?? null),
    this.saffirSimpsonRating = formBuilder.control(data.saffirSimpsonRating  ?? null),
    this.lowestPressure = formBuilder.control(data.lowestPressure ?? null),
    this.maxWindSpeed = formBuilder.control(data.maxWindSpeed ?? null),
    this.richterMagnitude = formBuilder.control(data.richterMagnitude ?? null),
    this.mercalliIntensity = formBuilder.control(data.mercalliIntensity ?? null),
    this.aftershocks = formBuilder.control(data.aftershocks ?? null),
    this.fault = formBuilder.control(data.fault ?? null),
    this.relatedTsunami = formBuilder.control(data.relatedTsunami ?? null)
  }
}
