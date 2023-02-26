import { BaseModel, RiskCategoryOutlookProbability } from './index';

export class RiskCategory extends BaseModel {
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
