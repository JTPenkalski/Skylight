import { BaseModel, IBaseModel } from "./index";

export interface ILocation extends IBaseModel {
  city: string;
  zipCode: string;
  country: string;
}

export class Location extends BaseModel implements ILocation {
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
