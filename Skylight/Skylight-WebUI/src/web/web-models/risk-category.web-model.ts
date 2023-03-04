import { BaseWebModel, RiskCategoryOutlookProbabilityWebModel } from './index';

export class RiskCategoryWebModel extends BaseWebModel {
  public readonly code: string;
  public readonly category: string;
  public readonly details: string;
  public readonly summary: string;
  public readonly riskProbabilities: RiskCategoryOutlookProbabilityWebModel[];

  constructor(
    id: number,
    code: string,
    category: string,
    details: string,
    summary: string,
    riskProbabilities: RiskCategoryOutlookProbabilityWebModel[]
  ) {
    super(id);
    this.code = code;
    this.category = category;
    this.details = details;
    this.summary = summary;
    this.riskProbabilities = riskProbabilities;
  }
}
