import { Observable } from 'rxjs';

export interface IService<T> {
  add(model: T): Observable<T | null>;

  get(id: number): Observable<T>;

  getAll(): Observable<T[]>;

  modify(id: number, model: T): Observable<boolean>;

  remove(id: number): Observable<boolean>;
}
