import { BaseModel } from './index';
import { ILocation as ILocationWebModel } from 'web/web-models';

export interface ILocation extends ILocationWebModel {
  // Add any Presentation Layer data fields here...
}

export class Location extends BaseModel implements ILocation {
  public city: string;
  public zipCode: string;
  public country: string;

  constructor(data?: ILocation) {
    super(data);
    
    this.city = this.str(data?.city);
    this.zipCode = this.str(data?.zipCode);
    this.country = this.str(data?.country);
  }
}
