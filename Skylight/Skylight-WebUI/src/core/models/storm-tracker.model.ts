import { BaseModel, IBaseModel } from "./index";

export interface IStormTracker extends IBaseModel {
  firstName: string;
  lastName: string;
  biography: string;
  startDate: Date;
  picturePath: string;
}

export class StormTracker extends BaseModel implements IStormTracker {
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
