import { Component } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { IFormControlInstance } from '../models/form-control-instance.model';
import { Location, Weather, WeatherEventAlert, WeatherEventStatistics, WeatherExperience } from 'models/index';

interface IWeatherEventForm {
  name: FormControl<string | null>;
  description: FormControl<string | null>;
  weather: FormControl<Weather | null>;
  startDate: FormControl<Date | null>;
  endDate: FormControl<Date | null>;
  weatherExperience: FormControl<WeatherExperience | null>;
  locations: FormArray;
  alerts: FormArray;
  statistics: FormControl<WeatherEventStatistics | null>;
}

@Component({
  selector: 'skylight-form-weather-event',
  templateUrl: './skylight-form-weather-event.component.html',
  styleUrls: ['./skylight-form-weather-event.component.scss']
})
export class SkylightFormWeatherEventComponent {
  public readonly weatherEvent: FormGroup<IWeatherEventForm>;

  constructor(
    private fb: FormBuilder
  ) {
    this.weatherEvent = this.fb.group<IWeatherEventForm>({
      name: this.fb.control('', Validators.required),
      description: this.fb.control(''),
      weather: this.fb.control(null, Validators.required),
      startDate: this.fb.control(new Date(), Validators.required),
      endDate: this.fb.control(null),
      weatherExperience: this.fb.control(null, Validators.required),
      locations: this.fb.array([]),
      alerts: this.fb.array([]),
      statistics: this.fb.control(null)
    });
  }

  public ngOnInit(): void {
    
  }

  public submit(): void {

  }

  public formControlInstance(name: string): IFormControlInstance {
    const formControl: AbstractControl | null = this.weatherEvent.get(name);

    if (!formControl) {
      throw new Error('Cannot create IFormControlInstance. Specified name is not a FormControl.');
    }

    return {
      name: name,
      formControl: formControl
    };
  }
}
