import { BaseModel } from './index';

export class StormTracker extends BaseModel {
  public firstName: string;
  public lastName: string;
  public biography?: string;
  public startDate: Date;
  public picturePath?: string;

  constructor(
    firstName: string = '',
    lastName: string = '',
    startDate: Date = new Date(),
    biography?: string,
    picturePath?: string,
    id?: number
  ) {
    super(id);
    this.firstName = firstName;
    this.lastName = lastName;
    this.biography = biography;
    this.startDate = startDate;
    this.picturePath = picturePath;
  }
}
