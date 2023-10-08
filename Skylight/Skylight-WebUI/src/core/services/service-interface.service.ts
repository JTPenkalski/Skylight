import { Observable } from 'rxjs';
import { FormGuideContext } from 'web/models';

/**
 * Base service for interacting with Web API Clients.
 **/
export interface IService<TModel, TFormGuide = undefined> {
  add(model: TModel): Observable<TModel | null>;

  get(id: number): Observable<TModel>;

  getAll(): Observable<TModel[]>;

  getFormGuide(model: TModel, context?: FormGuideContext) : Observable<TFormGuide>;

  modify(id: number, model: TModel): Observable<boolean>;

  remove(id: number): Observable<boolean>;
}
