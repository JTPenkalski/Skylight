import { Observable, of } from 'rxjs';

import { environment } from 'core/environments/environment';
import { IClient } from 'core/clients';
import { IHttpProtocol } from 'core/protocols';
import { CreateAtResult } from 'core/types';
import { BaseWebModel } from 'web/web-models';

export abstract class BaseClient<T extends BaseWebModel> implements IClient<T> { 
  protected readonly baseUrl: string;

  public abstract get controller(): string;
  public get endpoint(): string { return this.baseUrl + this.controller; }

  constructor(protected readonly client: IHttpProtocol<T>) { 
    this.baseUrl = `${environment.apiUrl}/${environment.apiVersion}/`;
    this.client.endpoint = this.endpoint;
  }

  public post(model: T): Observable<CreateAtResult<T>> {
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

  public put(id: number, model: T) : Observable<void> {
    return this.client.put(id, model);
  }

  public delete(id: number): Observable<void> {
    return this.client.delete(id);
  }

  protected validateUrl(): boolean {
    if (this.controller === '' || this.client.endpoint === '') {
      throw new Error('A Requestor is attempting to call the default endpoint. Ensure endpoints are initialized.')
    }

    return true;
  }
}
