import { IBaseWebModel } from './index';

export interface IStormTrackerWebModel extends IBaseWebModel {
  readonly firstName: string;
  readonly lastName: string;
  readonly biography?: string;
  readonly startDate: Date;
  readonly picturePath?: string;
}
