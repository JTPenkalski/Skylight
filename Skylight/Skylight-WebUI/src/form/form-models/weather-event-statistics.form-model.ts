import { FormControl } from '@angular/forms';

import { IBaseFormModel } from "./index";

export interface IWeatherEventStatisticsFormModel extends IBaseFormModel {
  readonly damageCost: FormControl<number | null>;
  readonly fatalities: FormControl<number | null>;
  readonly efRating: FormControl<string | null>;
  readonly pathDistance: FormControl<number | null>;
  readonly funnelWidth: FormControl<number | null>;
  readonly saffirSimpsonRating: FormControl<string | null>;
  readonly lowestPressure: FormControl<number | null>;
  readonly maxWindSpeed: FormControl<number | null>;
  readonly richterMagnitude: FormControl<number | null>;
  readonly mercalliIntensity: FormControl<number | null>;
  readonly aftershocks: FormControl<number | null>;
  readonly fault: FormControl<string | null>;
  readonly relatedTsunami: FormControl<boolean | null>;
}
