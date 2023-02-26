import { BaseModel, OutlookProbabilityWeatherType, RiskCategory } from './index';

export class RiskCategoryOutlookProbability extends BaseModel {
  public day: number;
  public chance: number;
  public significantSevere: boolean;
  public outlookProbabilityWeatherType: OutlookProbabilityWeatherType;
  public riskCategory: RiskCategory;

  constructor(
    id: number,
    day: number,
    chance: number,
    significantSevere: boolean,
    outlookProbabilityWeatherType: OutlookProbabilityWeatherType,
    riskCategory: RiskCategory
  ) {
    super(id);
    this.day = day;
    this.chance = chance;
    this.significantSevere = significantSevere;
    this.outlookProbabilityWeatherType = outlookProbabilityWeatherType;
    this.riskCategory = riskCategory;
    }
}
