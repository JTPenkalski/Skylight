import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SkylightServicesModule } from '../modules/skylight-services.module';

import { environment } from '../environments/environment'
import { WeatherAlert } from '../models/WeatherAlert';

@Injectable({
  providedIn: SkylightServicesModule
})
export class WeatherAlertsService {

  private readonly url: string;

  constructor(
    private http: HttpClient
  ) {
    this.url = environment.apiUrl + "WeatherAlerts/";
  }

  getWeatherAlerts(): Observable<WeatherAlert[]> {
    return this.http.get<WeatherAlert[]>(this.url);
  }
}
