import { Injectable } from '@angular/core';
import { Validators } from '@angular/forms';

import { BaseFormMapper } from './index';
import { Location } from 'core/models';
import { ILocationFormModel } from 'display/input/form-models';

@Injectable({
  providedIn: 'root'
})
export class LocationFormMapper extends BaseFormMapper<Location, ILocationFormModel> {
  public toPresentationModel(source: ILocationFormModel): Location {
    return new Location(
      source.city.value,
      source.zipCode.value,
      source.country.value
    );
  }

  public toFormModel(source: Location): ILocationFormModel {
    return {
      city: this.formBuilder.nonNullable.control(source.city, Validators.required),
      zipCode: this.formBuilder.nonNullable.control(source.zipCode, Validators.required),
      country: this.formBuilder.nonNullable.control(source.country, Validators.required)
    };
  }
}
