import { Component, Inject, Input } from '@angular/core';
import { AbstractControl, FormGroup } from '@angular/forms';

import { IWeatherEventService } from 'core/services';
import { WeatherEvent } from 'core/models';
import { WeatherEventService } from 'presentation/services';
import { WeatherEventFormMapper } from 'presentation/mappings';
import { IWeatherEventFormModel } from 'display/input/form-models';
import { IFormControlInstance } from 'display/input/controls/skylight-form-questions/models';

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

  public submit(): void {
    console.log('Submit');
    this.weatherEventService.add(this.weatherEventMapper.toPresentationModel(this.form.controls));
  }

  public getControlInstance(name: string): IFormControlInstance {
    const control: AbstractControl | null = this.form.get(name);

    if (!control) {
      throw new Error(`Cannot create IFormControlInstance. The control "${name}" is not a FormControl.`);
    }

    return {
      name: name,
      control: control
    };
  }
}