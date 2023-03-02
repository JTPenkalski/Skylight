import { Injectable } from '@angular/core';
import { Validators } from '@angular/forms';

import { BaseMapper } from './index';
import { Location } from 'core/models';
import { ILocationFormModel } from 'form/form-models';
import { ILocationWebModel } from 'communication/web-models';

@Injectable()
export class LocationMapper extends BaseMapper<ILocationWebModel, Location, ILocationFormModel> {
  public toWebModel(presentationModel: Location): ILocationWebModel
  {
    return {
      id: presentationModel.id,
      city: presentationModel.city,
      zipCode: presentationModel.zipCode,
      country: presentationModel.country
    };
  }
  
  public toPresentationModel(formModel: ILocationFormModel): Location {
    return new Location(
      formModel.city.value,
      formModel.zipCode.value,
      formModel.country.value
    );
  }

  public toFormModel(presentationModel: Location): ILocationFormModel {
    return {
      city: this.formBuilder.nonNullable.control(presentationModel.city, Validators.required),
      zipCode: this.formBuilder.nonNullable.control(presentationModel.zipCode, Validators.required),
      country: this.formBuilder.nonNullable.control(presentationModel.country, Validators.required)
    };
  }
}
