import { Injectable } from '@angular/core';

import { Location } from 'core/models';
import { LocationWebModel } from 'web/web-models';
import { BaseWebMapper } from './index';

@Injectable({
  providedIn: 'root'
})
export class LocationWebMapper extends BaseWebMapper<Location, LocationWebModel> {
  public toPresentationModel(source: LocationWebModel): Location
  {
    return new Location(
      source.city,
      source.zipCode,
      source.country,
      source.id
    );
  }

  public toWebModel(source: Location): LocationWebModel
  {
    return new LocationWebModel(
      source.id,
      source.city,
      source.zipCode,
      source.country
    );
  }
}
