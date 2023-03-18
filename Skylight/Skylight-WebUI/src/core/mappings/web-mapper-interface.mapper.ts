export interface IWebMapper<TPresentationModel, TWebModel> {
  toPresentationModel(source: TWebModel): TPresentationModel;

  toWebModel(source: TPresentationModel): TWebModel;
}