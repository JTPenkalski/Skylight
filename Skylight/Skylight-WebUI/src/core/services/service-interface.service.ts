import { Observable } from 'rxjs';

/**
 * Base service for interacting with Web API Clients.
 **/
export interface IService<T> {
  add(model: T): Observable<T | null>;

  get(id: number): Observable<T>;

  getAll(): Observable<T[]>;

  modify(id: number, model: T): Observable<boolean>;

  remove(id: number): Observable<boolean>;
}
