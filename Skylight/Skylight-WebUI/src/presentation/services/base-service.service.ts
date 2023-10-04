import { Observable } from 'rxjs';

import { IService } from 'core/services';
import { BaseModel } from 'presentation/models';
import { FormGuideContext } from 'web/models';

export abstract class BaseService<TPresentationModel extends BaseModel, TFormGuide = undefined> implements IService<TPresentationModel, TFormGuide> {
  public abstract add(model: TPresentationModel): Observable<TPresentationModel | null>;

  public abstract get(id: number): Observable<TPresentationModel>;

  public abstract getAll(): Observable<TPresentationModel[]>;
  
  public abstract getFormGuide(model: TPresentationModel, context?: FormGuideContext): Observable<TFormGuide>;

  public abstract modify(id: number, model: TPresentationModel) : Observable<boolean>;

  public abstract remove(id: number): Observable<boolean>;
}
