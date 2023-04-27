import { Component, Inject, Input } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormGroup } from '@angular/forms';

import { IWeatherEventService } from 'core/services';
import { WeatherEventService } from 'presentation/services';
import { IWeatherEvent as IWeatherEventCoreModel, WeatherEvent as WeatherEventCoreModel } from 'presentation/models';
import { ILocation, Location, IWeatherEvent, WeatherEvent, IWeatherEventAlert, WeatherEventAlert } from 'display/input/models';

@Component({
  selector: 'skylight-form-weather-event',
  templateUrl: './skylight-form-weather-event.component.html',
  styleUrls: ['./skylight-form-weather-event.component.scss']
})
export class SkylightFormWeatherEventComponent {
  @Input() public readonly model: IWeatherEventCoreModel = new WeatherEventCoreModel();

  public readonly form: FormGroup<IWeatherEvent>;

  constructor(
    protected readonly formBuilder: FormBuilder,
    @Inject(WeatherEventService) protected readonly weatherEventService: IWeatherEventService,
  ) {
    this.form = new FormGroup<IWeatherEvent>(new WeatherEvent(this.formBuilder, this.model));
    
  }

  /**
   * Submits the form to the server.
   **/
  public submit(): void {
    console.log(`Valid: ${this.form.valid}`);
    this.weatherEventService.add(new WeatherEventCoreModel(this.form.getRawValue())).subscribe();
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
