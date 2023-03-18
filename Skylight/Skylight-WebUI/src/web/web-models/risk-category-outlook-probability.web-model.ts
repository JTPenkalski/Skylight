import { OutlookProbabilityWeatherType } from 'core/models';
import { BaseWebModel } from './index';

export class RiskCategoryOutlookProbabilityWebModel extends BaseWebModel {
  public readonly day: number;
  public readonly chance: number;
  public readonly significantSevere: boolean;
  public readonly outlookProbabilityWeatherType: OutlookProbabilityWeatherType;

  constructor(
    id: number,
    day: number,
    chance: number,
    significantSevere: boolean,
    outlookProbabilityWeatherType: OutlookProbabilityWeatherType,
  ) {
    super(id);
    this.day = day;
    this.chance = chance;
    this.significantSevere = significantSevere;
    this.outlookProbabilityWeatherType = outlookProbabilityWeatherType;
  }
}
