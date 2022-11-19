import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../environments/environment'
import { WeatherAlert } from '../models/WeatherAlert';

@Injectable({
  providedIn: 'any'
})
export class WeatherAlertsService {

  private readonly url: string;

  constructor(
    private http: HttpClient
  ) {
    this.url = environment.apiUrl + "WeatherAlerts/";
  }

  public getWeatherAlerts(): Observable<WeatherAlert[]> {
    return this.http.get<WeatherAlert[]>(this.url);
  }
}
