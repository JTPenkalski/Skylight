import { BaseWebModel } from './index';

export class LocationWebModel extends BaseWebModel {
  public readonly city: string;
  public readonly zipCode: string;
  public readonly country: string;

  constructor(
    id: number,
    city: string,
    zipCode: string,
    country: string,
  ) {
    super(id);
    this.city = city;
    this.zipCode = zipCode;
    this.country = country;
  }
}
