import { Observable } from 'rxjs';

import { BaseModel } from 'core/models';

export interface IService<T extends BaseModel> {
  add(model: T): Observable<T | null>;

  get(id: number): Observable<T>;

  getAll(): Observable<T[]>;

  modify(id: number, model: T) : Observable<boolean>;

  remove(id: number): Observable<boolean>;
}
