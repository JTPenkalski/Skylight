/**
 * Base web model for all network communication with the Skylight Web API Controllers.
 * It is automatically extended by DTOs generated with NSwag.
 * 
 * However, because setting up inheritance with NSwag is terrible, this file is NOT automatically updated by changes to the ASP.NET Web Model,
 * meaning changes to BaseWebModel.cs must be manually modified here.
 **/
export abstract class BaseModel {
  public id?: number = 0;

  constructor(data?: IBaseModel) {
    this.id = data?.id ?? 0;
  }
}

export interface IBaseModel {
  id?: number;
}