import { Injectable } from '@angular/core';
import { Validators } from '@angular/forms';

import { BaseMapper } from './index';
import { Location } from 'core/models';
import { ILocationFormModel } from 'form/form-models';

@Injectable()
export class LocationMapper extends BaseMapper<Location, ILocationFormModel> {
  public toPresentationModel(formModel: ILocationFormModel): Location {
    return new Location(
      0,
      formModel.city.value,
      formModel.zipCode.value,
      formModel.country.value
    );
  }

  public toFormModel(presentationModel?: Location): ILocationFormModel {
    return {
      city: this.formBuilder.nonNullable.control(presentationModel?.city ?? '', Validators.required),
      zipCode: this.formBuilder.nonNullable.control(presentationModel?.zipCode ?? '', Validators.required),
      country: this.formBuilder.nonNullable.control(presentationModel?.country ?? '', Validators.required)
    };
  }
}
