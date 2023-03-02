import { Observable } from 'rxjs';

import { CreateAtResult } from 'core/types';
import { IBaseWebModel } from 'communication/web-models';

// TODO: Consider wrapping in some Response type to check response numbers/status. Could be helpful for PUT and DELETE.

export interface IRequestor<T extends IBaseWebModel> {
  post(model: T): Observable<CreateAtResult<T>>;

  get(id: number): Observable<T>;

  getAll(): Observable<T[]>;

  put(id: number, model: T) : Observable<void>;

  delete(id: number): Observable<void>;
}
