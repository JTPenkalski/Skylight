import { OutlookProbabilityWeatherType } from 'core/models';
import { IBaseWebModel, IRiskCategoryWebModel } from './index';

export interface IRiskCategoryOutlookProbabilityWebModel extends IBaseWebModel {
  readonly day: number;
  readonly chance: number;
  readonly significantSevere: boolean;
  readonly outlookProbabilityWeatherType: OutlookProbabilityWeatherType;
  readonly riskCategory: IRiskCategoryWebModel;
}
