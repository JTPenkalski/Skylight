import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { SkylightFormComponent } from '../skylight-form.component';
import { IWeatherEventService } from 'core/services';
import { WeatherEventService } from 'presentation/services';
import { IWeatherEvent as IWeatherEventCoreModel, WeatherEvent as WeatherEventCoreModel } from 'presentation/models';
import {
  IWeatherEvent, WeatherEvent,
  IWeatherEventLocation, WeatherEventLocation,
  IWeatherEventAlert, WeatherEventAlert
} from 'display/input/models';
import { WeatherEventFormGuide } from 'web/models';

@Component({
  selector: 'skylight-form-weather-event',
  templateUrl: './skylight-form-weather-event.component.html',
  styleUrls: ['./skylight-form-weather-event.component.scss']
})
export class SkylightFormWeatherEventComponent extends SkylightFormComponent<IWeatherEventCoreModel, IWeatherEvent, WeatherEventFormGuide> {
  constructor(
    formBuilder: FormBuilder,
    @Inject(WeatherEventService) service: IWeatherEventService,
  ) {
    super(formBuilder, service);
  }

  public override ngOnInit(): void {
    this.form = new FormGroup<IWeatherEvent>(new WeatherEvent(this.formBuilder, this.model));
    this.requestGuide();
  }

  public override submit(): void {
    this.service.add(new WeatherEventCoreModel(this.form.getRawValue())).subscribe();
  }

  public override reset(): void {
    this.form?.reset();
    this.requestGuide();
  }

  public override requestGuide(): void {
    this.service.getFormGuide(new WeatherEventCoreModel(this.form.getRawValue())).subscribe(guide => {
      this.guide = guide;
      console.log(guide);
    });
  }

  public addWeatherEventAlert(): void {
    this.form.controls.alerts.push(new FormGroup<IWeatherEventAlert>(new WeatherEventAlert(this.formBuilder)));
    this.requestGuide();
  }

  public removeWeatherEventAlert(index: number): void {
    this.form.controls.alerts.removeAt(index);
    this.requestGuide();
  }

  public addWeatherEventLocation(): void {
    this.form.controls.locations.push(new FormGroup<IWeatherEventLocation>(new WeatherEventLocation(this.formBuilder)));
    this.requestGuide();
  }

  public removeWeatherEventLocation(index: number): void {
    this.form.controls.locations.removeAt(index);
    this.requestGuide();
  }
}
