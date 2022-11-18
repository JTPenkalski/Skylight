import { Component, OnInit } from '@angular/core';
import { WeatherAlert } from '../models/WeatherAlert';

@Component({
  selector: 'skylight-dropdown-weather-alert',
  templateUrl: './dropdown-weather-alert.component.html',
  styleUrls: ['./dropdown-weather-alert.component.scss']
})
export class DropdownWeatherAlertComponent implements OnInit {
  options: WeatherAlert[] = [
    {
      id: 1,
      name: "Alert 1",
      description: "Description",
      value: 1,
      thirdParty: false
    },
    {
      id: 2,
      name: "Alert 2",
      description: "Description",
      value: 2,
      thirdParty: false
    },
    {
      id: 3,
      name: "Alert 3",
      description: "Description",
      value: 2,
      thirdParty: false
    }
  ]

  constructor() { }

  ngOnInit(): void {
    
  }

}
