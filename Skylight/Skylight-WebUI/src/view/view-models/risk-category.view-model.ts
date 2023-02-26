import { IBaseViewModel, IRiskCategoryOutlookProbabilityViewModel } from './index';

export interface IRiskCategoryViewModel extends IBaseViewModel {
  readonly code: string;
  readonly category: string;
  readonly details: string;
  readonly summary: string;
  readonly riskProbabilities: IRiskCategoryOutlookProbabilityViewModel[];
}
