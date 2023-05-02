import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { SkylightFormComponent } from '../skylight-form.component';
import { IWeatherEventService } from 'core/services';
import { WeatherEventService } from 'presentation/services';
import { IWeatherEvent as IWeatherEventCoreModel, WeatherEvent as WeatherEventCoreModel } from 'presentation/models';
import {
  IWeatherEvent, WeatherEvent,
  ILocation, Location,
  IWeatherEventAlert, WeatherEventAlert
} from 'display/input/models';

@Component({
  selector: 'skylight-form-weather-event',
  templateUrl: './skylight-form-weather-event.component.html',
  styleUrls: ['./skylight-form-weather-event.component.scss']
})
export class SkylightFormWeatherEventComponent extends SkylightFormComponent<IWeatherEventCoreModel, IWeatherEvent> {
  constructor(
    formBuilder: FormBuilder,
    @Inject(WeatherEventService) service: IWeatherEventService,
  ) {
    super(formBuilder, service);
  }

  public override ngOnInit(): void {
    this.form = new FormGroup<IWeatherEvent>(new WeatherEvent(this.formBuilder, this.model));
  }

  public override submit(): void {
    this.service.add(new WeatherEventCoreModel(this.form.getRawValue())).subscribe();
  }

  public addWeatherEventAlert(): void {
    this.form.controls.alerts.push(new FormGroup<IWeatherEventAlert>(new WeatherEventAlert(this.formBuilder)));
  }

  public removeWeatherEventAlert(index: number): void {
    this.form.controls.alerts.removeAt(index);
  }

  public addLocation(): void {
    this.form.controls.locations.push(new FormGroup<ILocation>(new Location(this.formBuilder)));
  }

  public removeLocation(index: number): void {
    this.form.controls.locations.removeAt(index);
  }
}
