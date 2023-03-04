import { Observable } from 'rxjs';

import { IService } from 'core/services';
import { IClient } from 'core/clients';
import { IWebMapper } from 'core/mappings';
import { BaseModel } from 'core/models';
import { BaseWebModel } from 'web/web-models';

export abstract class BaseService<TWebModel extends BaseWebModel, TPresentationModel extends BaseModel> implements IService<TPresentationModel> { 
  constructor(
    protected readonly client: IClient<TWebModel>,
    protected readonly mapper: IWebMapper<TPresentationModel, TWebModel>
  ) { }

  public abstract add(model: TPresentationModel): Observable<TPresentationModel | null>;

  public abstract get(id: number): Observable<TPresentationModel>;

  public abstract getAll(): Observable<TPresentationModel[]>;

  public abstract modify(id: number, model: TPresentationModel) : Observable<boolean>;

  public abstract remove(id: number): Observable<boolean>;
}
