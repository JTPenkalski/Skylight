import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

import { IWeather } from 'models/index';

interface IWeatherEventForm {
  name: FormControl<string | null>;
  description: FormControl<string | null>;
  weather: FormControl<IWeather | null>;
  startDate: FormControl<Date | null>;
  endDate: FormControl<Date | null>;
  weatherExperience: FormControl<string | null>;
  locations: FormArray<any | null>;
  alerts: FormArray<any | null>;
  statistics: FormControl<string | null>;
}

@Component({
  selector: 'skylight-form-weather-event',
  templateUrl: './skylight-form-weather-event.component.html',
  styleUrls: ['./skylight-form-weather-event.component.scss']
})
export class SkylightFormWeatherEventComponent implements OnInit {
  public readonly weatherEvent: FormGroup<IWeatherEventForm>;
  public weatherOptions: IWeather[] = [];

  constructor(
    private fb: FormBuilder,
    private http: HttpClient
  ) {
    this.weatherEvent = this.fb.group<IWeatherEventForm>({
      name: this.fb.control('', Validators.required),
      description: this.fb.control(''),
      weather: this.fb.control(null, Validators.required),
      startDate: this.fb.control(new Date(), Validators.required),
      endDate: this.fb.control(new Date()),
      weatherExperience: this.fb.control('', Validators.required),
      locations: this.fb.array([]),
      alerts: this.fb.array([]),
      statistics: this.fb.control('')
    });
  }

  public ngOnInit(): void {
    this.http.get<IWeather[]>('https://localhost:7147/api/v1/Weather').subscribe(result => {
      this.weatherOptions = result;
    });
  }

  public submit(): void {

  }
}
