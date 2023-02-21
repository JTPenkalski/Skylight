import { BaseModel, IBaseModel, OutlookProbabilityWeatherType, RiskCategory } from "./index";

export interface IRiskCategoryOutlookProbability extends IBaseModel {
  day: number;
  chance: number;
  significantSevere: boolean;
  outlookProbabilityWeatherType: OutlookProbabilityWeatherType;
  riskCategory: RiskCategory;
}

export class RiskCategoryOutlookProbability extends BaseModel implements IRiskCategoryOutlookProbability {
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
