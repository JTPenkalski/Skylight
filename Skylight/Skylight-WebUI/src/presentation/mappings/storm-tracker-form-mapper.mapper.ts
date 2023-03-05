import { Injectable } from '@angular/core';

import { BaseFormMapper } from './index';
import { StormTracker } from 'core/models';

@Injectable({
  providedIn: 'root'
})
export class StormTrackerFormMapper extends BaseFormMapper<StormTracker, any> {  
  public toPresentationModel(source: any): StormTracker {
    throw new Error('Not implemented.');
  }

  public toDisplayModel(source: StormTracker): any {
    throw new Error('Not implemented.');
  }
}
