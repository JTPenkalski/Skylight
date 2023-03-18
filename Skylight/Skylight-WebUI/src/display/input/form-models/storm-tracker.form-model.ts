import { FormControl } from '@angular/forms';

import { IBaseFormModel } from './index';

export interface IStormTrackerFormModel extends IBaseFormModel {
  readonly firstName: FormControl<string>;
  readonly lastName: FormControl<string>;
  readonly biography: FormControl<string>;
  readonly startDate: FormControl<Date>;
  readonly picturePath: FormControl<string>;
}
