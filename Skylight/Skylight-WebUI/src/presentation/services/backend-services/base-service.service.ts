import { Observable, map } from 'rxjs';

import { IService } from 'core/services';
import { BaseModel } from 'core/models';
import { IRequestor } from 'core/requestors';
import { IBaseWebModel } from 'communication/web-models';
import { BaseMapper } from 'presentation/services/mappers';

export abstract class BaseService<TWebModel extends IBaseWebModel, TPresentationModel extends BaseModel> implements IService<TPresentationModel> { 
  constructor(
    protected readonly requestor: IRequestor<TWebModel>,
    protected readonly mapper: BaseMapper<TWebModel, TPresentationModel, any>
  ) { }

  public add(model: TPresentationModel): Observable<TPresentationModel | null> {
    return this.requestor.post(this.mapper.toWebModel(model)).pipe(
      map(result => result.value ?? null)
    );
  }

  public get(id: number): Observable<TPresentationModel> {
    return this.requestor.get(id);
  }

  public getAll(): Observable<TPresentationModel[]> {
    return this.requestor.getAll();
  }

  public modify(id: number, model: TPresentationModel) : Observable<boolean> {
    throw new Error('Not implemented.');
  }

  public remove(id: number): Observable<boolean> {
    throw new Error('Not implemented.');
  }
}
