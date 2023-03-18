import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IHttpProtocol } from 'core/protocols';
import { CreateAtResult } from 'core/types';

// TODO: If we used a third-party HTTP library, we could move to Web layer.

@Injectable({
  providedIn: 'root'
})
export class HttpProtocol<T> implements IHttpProtocol<T> {
  protected _endpoint: string = '';

  public get endpoint(): string { return this._endpoint; }
  public set endpoint(value: string) { this._endpoint = value; }

  constructor(protected client: HttpClient) { }

  public post(model: T): Observable<CreateAtResult<T>> {
    throw new Error('Not implemented.');
  }

  public get(id: number): Observable<T> {
    throw new Error('Not implemented.');
  }

  public getAll(): Observable<T[]> {
    return this.client.get<T[]>(this.endpoint);
  }

  public put(id: number, model: T) : Observable<void> {
    throw new Error('Not implemented.');
  }

  public delete(id: number): Observable<void> {
    throw new Error('Not implemented.');
  }
}
