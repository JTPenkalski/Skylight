import { Injectable } from '@angular/core';

import { BaseMapper } from './index';
import { StormTracker } from 'core/models';
import { IStormTrackerWebModel } from 'communication/web-models';

@Injectable()
export class StormTrackerMapper extends BaseMapper<IStormTrackerWebModel, StormTracker, any> {  
  public toWebModel(presentationModel: StormTracker): IStormTrackerWebModel
  {
    return {
      id: presentationModel.id,
      firstName: presentationModel.firstName,
      lastName: presentationModel.lastName,
      biography: presentationModel.biography,
      startDate: presentationModel.startDate,
      picturePath: presentationModel.picturePath
    };
  }

  public toPresentationModel(formModel: any): StormTracker {
    throw new Error('Not implemented.');
  }

  public toFormModel(presentationModel: StormTracker): any {
    throw new Error('Not implemented.');
  }
}
