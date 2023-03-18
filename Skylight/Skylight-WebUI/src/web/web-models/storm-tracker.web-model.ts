import { BaseWebModel } from './index';

export class StormTrackerWebModel extends BaseWebModel {
  public readonly firstName: string;
  public readonly lastName: string;
  public readonly startDate: Date;
  public readonly biography?: string;
  public readonly picturePath?: string;

  constructor(
    id: number,
    firstName: string,
    lastName: string,
    startDate: Date,
    biography?: string,
    picturePath?: string
  ) {
    super(id);
    this.firstName = firstName;
    this.lastName = lastName;
    this.startDate = startDate;
    this.biography = biography;
    this.picturePath = picturePath;
  }
}
