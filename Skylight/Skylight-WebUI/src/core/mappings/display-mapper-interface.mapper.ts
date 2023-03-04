export interface IDisplayMapper<TPresentationModel, TDisplayModel> {
  toPresentationModel(source: TDisplayModel): TPresentationModel;

  toDisplayModel(source: TPresentationModel): TDisplayModel;
}
