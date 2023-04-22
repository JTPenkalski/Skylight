import { OutlookProbabilityWeatherType } from 'presentation/models';
import { IBaseViewModel } from './index';

export interface IRiskCategoryOutlookProbabilityViewModel extends IBaseViewModel {
  readonly day: number;
  readonly chance: number;
  readonly significantSevere: boolean;
  readonly outlookProbabilityWeatherType: OutlookProbabilityWeatherType;
}
