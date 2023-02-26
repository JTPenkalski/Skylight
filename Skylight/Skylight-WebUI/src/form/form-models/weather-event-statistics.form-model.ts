import { FormControl } from '@angular/forms';

import { IBaseFormModel } from "./index";

export interface IWeatherEventStatisticsFormModel extends IBaseFormModel {
  readonly damageCost: FormControl<number>;
  readonly fatalities: FormControl<number>;
  readonly efRating: FormControl<string>;
  readonly pathDistance: FormControl<number>;
  readonly funnelWidth: FormControl<number>;
  readonly saffirSimpsonRating: FormControl<string>;
  readonly lowestPressure: FormControl<number>;
  readonly maxWindSpeed: FormControl<number>;
  readonly richterMagnitude: FormControl<number>;
  readonly mercalliIntensity: FormControl<number>;
  readonly aftershocks: FormControl<number>;
  readonly fault: FormControl<string>;
  readonly relatedTsunami: FormControl<boolean>;
}
