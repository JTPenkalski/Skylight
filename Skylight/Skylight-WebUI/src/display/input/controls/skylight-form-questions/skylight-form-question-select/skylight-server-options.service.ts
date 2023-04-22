import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

import { environment } from 'core/environments/environment';
import { ISelectOption } from '../types/select-option';

/**
 * Retrieves options for a dropdown control from an endpoint on the server.
 **/
@Injectable()
export class SkylightServerOptionsService {
  private readonly url: string;

  constructor(
    private http: HttpClient
  ) {
    this.url = `${environment.apiUrl}/${environment.apiVersion}/`;
  }

  /**
   * Makes a call to the server to get all values from the database for the specified endpoint.
   * @param controller The API Controller to call to retrieve values from the database.
   * @returns An Observable containing an array of all items from the database.
   **/
  public getOptions(controller: string): Observable<ISelectOption[]> {
    return this.http.get<any[]>(this.url + controller).pipe(
      map(response => {
        return response.map(x => {
          return {
            name: x.name,
            value: x
          };
        });
      })
    );
  }
}
