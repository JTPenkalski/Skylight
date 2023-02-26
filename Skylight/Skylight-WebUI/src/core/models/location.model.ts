import { BaseModel } from './index';

export class Location extends BaseModel {
  public city: string;
  public zipCode: string;
  public country: string;

  constructor (id: number, city: string, zipCode: string, country: string) {
    super(id);
    this.city = city;
    this.zipCode = zipCode;
    this.country = country;
  }
}
