import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { WeatherEvent } from '../../models';

@Injectable({
  providedIn: 'root'
})
export class WeatherEventService {
  constructor(private readonly client: HttpClient) { }

  public getWeatherEventById(id: string) {
    return this.client.post<WeatherEvent>('/api/GetWeatherEventById', {}).subscribe(result => {
      console.log('Result:', result);
    });
  }
}
