import { BaseModel } from './index';

export class StormTracker extends BaseModel {
  public firstName: string;
  public lastName: string;
  public biography: string;
  public startDate: Date;
  public picturePath: string;

  constructor(
    id: number,
    firstName: string,
    lastName: string,
    biography: string,
    startDate: Date,
    picturePath: string
  ) {
    super(id);
    this.firstName = firstName;
    this.lastName = lastName;
    this.biography = biography;
    this.startDate = startDate;
    this.picturePath = picturePath;
  }
}
