import { FormControl } from '@angular/forms';

import { IBaseFormModel } from './index';

export interface ILocationFormModel extends IBaseFormModel {
  readonly city: FormControl<string>;
  readonly zipCode: FormControl<string>;
  readonly country: FormControl<string>;
}
