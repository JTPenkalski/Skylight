import { Component, OnInit } from '@angular/core';
import { WeatherAlert } from '../../models/WeatherAlert';
import { WeatherAlertsService } from '../../services/weather-alerts.service';

@Component({
  selector: 'skylight-dropdown-weather-alert',
  templateUrl: './dropdown-weather-alert.component.html',
  styleUrls: ['./dropdown-weather-alert.component.scss']
})
export class DropdownWeatherAlertComponent implements OnInit {
  options!: WeatherAlert[];

  constructor(
    private weatherAlertsService: WeatherAlertsService
  ) {

  }

  ngOnInit(): void {
    this.weatherAlertsService
      .getWeatherAlerts()
      .subscribe(
        (response: WeatherAlert[]) => this.options = response.sort((a, b) => a.name.localeCompare(b.name)),
        (error) => console.error(error)
      );
  }
}
