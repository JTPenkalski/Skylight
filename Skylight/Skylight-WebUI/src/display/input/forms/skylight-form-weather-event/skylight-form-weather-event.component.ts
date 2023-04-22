import { Component, Inject, Input } from '@angular/core';
import { AbstractControl, FormArray, FormGroup } from '@angular/forms';

import { IWeatherEventService } from 'core/services';
import { Location, WeatherEvent, WeatherEventAlert } from 'presentation/models';
import { WeatherEventService } from 'presentation/services';
import { LocationFormMapper, WeatherEventAlertFormMapper, WeatherEventFormMapper } from 'presentation/mappings';
import { ILocationFormModel, IWeatherEventAlertFormModel, IWeatherEventFormModel } from 'display/input/form-models';
import { IAbstractControlInstance } from 'display/input/controls/skylight-form-questions/types';

@Component({
  selector: 'skylight-form-weather-event',
  templateUrl: './skylight-form-weather-event.component.html',
  styleUrls: ['./skylight-form-weather-event.component.scss']
})
export class SkylightFormWeatherEventComponent {
  @Input() public readonly model: WeatherEvent = new WeatherEvent();

  public readonly form: FormGroup<IWeatherEventFormModel>;

  constructor(
    @Inject(WeatherEventService) protected readonly weatherEventService: IWeatherEventService,
    protected readonly weatherEventMapper: WeatherEventFormMapper,
    protected readonly weatherEventAlertMapper: WeatherEventAlertFormMapper,
    protected readonly locationMapper: LocationFormMapper
  ) {
    this.form = new FormGroup<IWeatherEventFormModel>(this.weatherEventMapper.toDisplayModel(this.model));
  }

  /**
   * Submits the form to the server.
   **/
  public submit(): void {
    console.log(`Valid: ${this.form.valid}`);
    this.weatherEventService.add(this.weatherEventMapper.toPresentationModel(this.form.controls)).subscribe();
    this.form.getRawValue();
  }

  /**
   * Maps an AbstractControl to an AbstractControlInstance.
   * @param name The name or index of the AbstractControl within a control.
   * @param parent Optionally provide a more specific parent to search under.
   * @returns An object with the AbstractControl and its name within the FormGroup.
   **/
  public getControlInstance(name: string | number, parent?: FormGroup | FormArray): IAbstractControlInstance {
    name = name.toString(); // Convert string | number to string
    const control: AbstractControl | null = parent?.get(name) ?? this.form.get(name);

    if (!control) {
      throw new Error(`Cannot create IAbstractControlInstance. The control "${name}" is not an AbstractControl.`);
    }

    return {
      name: name,
      control: control
    };
  }

  public addWeatherEventAlert(): void {
    this.form.controls.alerts.push(new FormGroup<IWeatherEventAlertFormModel>(this.weatherEventAlertMapper.toDisplayModel(new WeatherEventAlert())));
  }

  public removeWeatherEventAlert(index: number): void {
    this.form.controls.alerts.removeAt(index);
  }

  public addLocation(): void {
    this.form.controls.locations.push(new FormGroup<ILocationFormModel>(this.locationMapper.toDisplayModel(new Location())));
  }

  public removeLocation(index: number): void {
    this.form.controls.locations.removeAt(index);
  }
}
