import { Component, Inject, Input } from '@angular/core';
import { AbstractControl, FormGroup } from '@angular/forms';

import { IWeatherEventService } from 'core/services';
import { WeatherEvent } from 'core/models';
import { WeatherEventService } from 'presentation/services';
import { WeatherEventFormMapper } from 'presentation/mappings';
import { IWeatherEventFormModel } from 'display/input/form-models';
import { IAbstractControlInstance } from 'display/input/controls/skylight-form-questions/models';

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
    protected readonly weatherEventMapper: WeatherEventFormMapper
  ) {
    this.form = new FormGroup<IWeatherEventFormModel>(this.weatherEventMapper.toDisplayModel(this.model));
  }

  /**
   * Submits the form to the server.
   **/
  public submit(): void {
    console.log('Submit');
    console.log(this.form);
    this.weatherEventService.add(this.weatherEventMapper.toPresentationModel(this.form.controls));
  }

  /**
   * Maps an AbstractControl to an AbstractControlInstance.
   * @param name The name of the AbstractControl within a FormGroup.
   * @returns An object with the AbstractControl and its name within the FormGroup.
   **/
  public getControlInstance(name: string): IAbstractControlInstance {
    const control: AbstractControl | null = this.form.get(name);

    if (!control) {
      throw new Error(`Cannot create IAbstractControlInstance. The control "${name}" is not an AbstractControl.`);
    }

    return {
      name: name,
      control: control
    };
  }
}
