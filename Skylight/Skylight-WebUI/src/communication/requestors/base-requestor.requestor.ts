import { Observable, of } from 'rxjs';

import { environment } from 'core/environments/environment';
import { IRequestor } from 'core/requestors';
import { IHttpControllerClient } from 'core/services';
import { CreateAtResult } from 'core/types';
import { BaseModel } from 'core/models';

export abstract class BaseRequestor<T extends BaseModel> implements IRequestor<T> { 
  protected readonly baseUrl: string;

  public abstract get controller(): string;
  public get endpoint(): string { return this.baseUrl + this.controller; }

  constructor(protected readonly client: IHttpControllerClient<T>) { 
    this.baseUrl = `${environment.apiUrl}/${environment.apiVersion}/`;
  }

  public add(model: T): Observable<CreateAtResult<T>> {
    if (this.validateUrl()) {
      return this.client.post(model);
    }

    return of({
      actionName: `Post${this.controller}`,
      controllerName: this.controller,
      routeValues: { id: model.id }
    });
  }

  public get(id: number): Observable<T> {
    return this.client.get(id);
  }

  public getAll(): Observable<T[]> {
    return this.client.getAll();
  }

  public modify(id: number, model: T) : Observable<void> {
    return this.client.put(id, model);
  }

  public remove(id: number): Observable<void> {
    return this.client.delete(id);
  }

  protected validateUrl(): boolean {
    if (this.controller === '' || this.client.endpoint === '') {
      throw new Error('A Requestor is attempting to call the default endpoint. Ensure endpoints are initialized.')
    }

    return true;
  }
}
