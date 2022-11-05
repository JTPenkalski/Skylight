import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { WeatherType } from '../../models/WeatherType'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public weatherTypes?: WeatherType[];

  constructor(http: HttpClient) {
    http.get<WeatherType[]>('https://localhost:7147/api/weathertypes').subscribe(result => { this.weatherTypes = result; }, error => console.error(error));
  }

  title = 'Skylight';
}
