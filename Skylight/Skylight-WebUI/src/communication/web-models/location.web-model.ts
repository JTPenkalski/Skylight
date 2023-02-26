import { IBaseWebModel } from './index';

export interface ILocationWebModel extends IBaseWebModel {
  readonly city: string;
  readonly zipCode: string;
  readonly country: string;
}
