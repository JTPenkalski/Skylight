import { BaseModel } from './index';

export class Location extends BaseModel {
  public city: string;
  public zipCode: string;
  public country: string;

  constructor(
    city: string = '',
    zipCode: string = '',
    country: string = '',
    id?: number
  ) {
    super(id);
    this.city = city;
    this.zipCode = zipCode;
    this.country = country;
  }
}
