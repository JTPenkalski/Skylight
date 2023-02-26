import { Observable } from 'rxjs';

import { CreateAtResult } from 'core/types';

// TODO: Consider wrapping in some Response type to check response numbers/status. Could be helpful for PUT and DELETE.
// TODO: Could also abstract to an IClient<T> to dynamically switch protocols?

export interface IHttpControllerClient<T> {
  get endpoint(): string;
  set endpoint(value: string);

  post(model: T): Observable<CreateAtResult<T>>;

  get(id: number): Observable<T>;

  getAll(): Observable<T[]>;

  put(id: number, model: T) : Observable<void>;

  delete(id: number): Observable<void>;
}
