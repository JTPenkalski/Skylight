import { IWebMapper } from 'core/mappings';
import { BaseModel } from 'core/models';
import { BaseWebModel } from 'web/web-models';

export abstract class BaseWebMapper<TPresentationModel extends BaseModel, TWebModel extends BaseWebModel> implements IWebMapper<TPresentationModel, TWebModel>
{
  public abstract toPresentationModel(source: TWebModel): TPresentationModel;

  public abstract toWebModel(source: TPresentationModel): TWebModel;
}
