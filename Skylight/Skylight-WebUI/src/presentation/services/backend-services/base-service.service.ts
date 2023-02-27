import { Observable, map } from 'rxjs';

import { IService } from 'core/services';
import { BaseModel } from 'core/models';
import { IRequestor } from 'core/requestors';

export abstract class BaseService<T extends BaseModel> implements IService<T> { 
  constructor(protected readonly requestor: IRequestor<T>) { }

  public add(model: T): Observable<T | null> {
    return this.requestor.post(model).pipe(
      map(result => result.value ?? null)
    )
  }

  public get(id: number): Observable<T> {
    return this.requestor.get(id);
  }

  public getAll(): Observable<T[]> {
    return this.requestor.getAll();
  }

  public modify(id: number, model: T) : Observable<boolean> {
    throw new Error('Not implemented.');
  }

  public remove(id: number): Observable<boolean> {
    throw new Error('Not implemented.');
  }
}
