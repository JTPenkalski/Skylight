import { BaseModel, IBaseModel, RiskCategoryOutlookProbability } from "./index";

export interface IRiskCategory extends IBaseModel {
  code: string;
  category: string;
  details: string;
  summary: string;
  riskProbabilities: RiskCategoryOutlookProbability[];
}

export class RiskCategory extends BaseModel implements IRiskCategory {
  public code: string;
  public category: string;
  public details: string;
  public summary: string;
  public riskProbabilities: RiskCategoryOutlookProbability[];

  constructor(
    id: number,
    code: string,
    category: string,
    details: string,
    summary: string,
    riskProbabilities: RiskCategoryOutlookProbability[]
  ) {
    super(id);
    this.code = code;
    this.category = category;
    this.details = details;
    this.summary = summary;
    this.riskProbabilities = riskProbabilities;
  }
}
