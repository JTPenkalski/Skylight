import { Injectable } from '@angular/core';

import { StormTracker } from 'core/models';
import { StormTrackerWebModel } from 'web/web-models';
import { BaseWebMapper } from './index';

@Injectable({
  providedIn: 'root'
})
export class StormTrackerWebMapper extends BaseWebMapper<StormTracker, StormTrackerWebModel> {
  public toPresentationModel(source: StormTrackerWebModel): StormTracker
  {
    return new StormTracker(
      source.firstName,
      source.lastName,
      source.startDate,
      source.biography,
      source.picturePath,
      source.id
    );
  }

  public toWebModel(source: StormTracker): StormTrackerWebModel
  {
    return new StormTrackerWebModel(
      source.id,
      source.firstName,
      source.lastName,
      source.startDate,
      source.biography,
      source.picturePath
    );
  }
}
