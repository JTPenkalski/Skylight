import { FormBuilder, FormControl, Validators } from '@angular/forms';

import { zipCodeValidator } from '../validators';
import { BaseModel, IBaseModel } from './index';
import {
  Location as LocationCoreModel, ILocation as ILocationCoreModel
} from 'presentation/models';

export interface ILocation extends IBaseModel {
  readonly city: FormControl<string>;
  readonly zipCode: FormControl<string>;
  readonly country: FormControl<string>;
}

export class Location extends BaseModel implements ILocation {
  public readonly city: FormControl<string>;
  public readonly zipCode: FormControl<string>;
  public readonly country: FormControl<string>;

  constructor(formBuilder: FormBuilder, data?: ILocationCoreModel) {
    super();
    
    data ??= new LocationCoreModel();

    this.city = formBuilder.nonNullable.control(data.city, Validators.required);
    this.zipCode = formBuilder.nonNullable.control(data.zipCode, [Validators.required, zipCodeValidator]);
    this.country = formBuilder.nonNullable.control(data.country, Validators.required);
  }
}
