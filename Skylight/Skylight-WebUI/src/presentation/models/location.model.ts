import { BaseModel, IBaseModel } from './index';
import { ILocation as ILocationWebModel } from 'web/models';

export interface ILocation extends ILocationWebModel, IBaseModel {
  // Add any Presentation Layer data fields here...
}

export class Location extends BaseModel implements ILocation {
  public city: string;
  public country: string;

  constructor(data?: ILocation) {
    super(data);
    
    this.city = this.str(data?.city);
    this.country = this.str(data?.country);
  }
}
