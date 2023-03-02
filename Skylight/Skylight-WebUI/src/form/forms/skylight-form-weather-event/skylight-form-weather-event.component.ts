import { Component, Inject } from '@angular/core';
import { AbstractControl, FormGroup } from '@angular/forms';

import { IWeatherEventService } from 'core/services';
import { WeatherEventMapper } from 'presentation/services/mappers';
import { WeatherEventService } from 'presentation/services/backend-services';
import { IFormQuestionInstance } from 'form/controls/skylight-form-question/models/form-control-instance.model';
import { IWeatherEventFormModel } from 'form/form-models';
import { WeatherEvent } from 'core/models';

@Component({
  selector: 'skylight-form-weather-event',
  templateUrl: './skylight-form-weather-event.component.html',
  styleUrls: ['./skylight-form-weather-event.component.scss']
})
export class SkylightFormWeatherEventComponent {
  public readonly weatherEvent: FormGroup<IWeatherEventFormModel>;

  constructor(
    @Inject(WeatherEventService) protected readonly weatherEventService: IWeatherEventService,
    protected readonly weatherEventMapper: WeatherEventMapper
  ) {
    this.weatherEvent = new FormGroup<IWeatherEventFormModel>(this.weatherEventMapper.toFormModel());
  }

  public ngOnInit(): void {
    
  }

  public submit(): void {
    console.log('Submit');
    this.weatherEventService.add(this.weatherEventMapper.toPresentationModel(this.weatherEvent.controls));
  }

  public formQuestionInstance<T extends AbstractControl<T, T>>(name: string): IFormQuestionInstance {
    const control: AbstractControl<T, T> | null = this.weatherEvent.get(name);

    if (!control) {
      throw new Error(`Cannot create IFormControlInstance. The control "${name}" is not a FormControl.`);
    }

    return {
      name: name,
      control: control
    };
  }
}
