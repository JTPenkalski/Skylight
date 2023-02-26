import { IBaseWebModel, IRiskCategoryOutlookProbabilityWebModel } from './index';

export interface IRiskCategoryWebModel extends IBaseWebModel {
  readonly code: string;
  readonly category: string;
  readonly details: string;
  readonly summary: string;
  readonly riskProbabilities: IRiskCategoryOutlookProbabilityWebModel[];
}
