import { Component, OnInit } from '@angular/core';
import { WeatherAlert } from '../../models/WeatherAlert';
import { WeatherAlertsService } from '../../services/weather-alerts.service';

@Component({
  selector: 'skylight-dropdown-weather-alert',
  templateUrl: './dropdown-weather-alert.component.html',
  styleUrls: ['./dropdown-weather-alert.component.scss']
})
export class DropdownWeatherAlertComponent implements OnInit {

  constructor(
    private weatherAlertsService: WeatherAlertsService
  ) {

  }

  ngOnInit(): void {
    
  }

}
