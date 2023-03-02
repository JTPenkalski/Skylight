import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

import { BaseMapper, WeatherAlertMapper, WeatherAlertModifierMapper, WeatherEventMapper } from './index';
import { WeatherEventAlert } from 'core/models';
import { IWeatherEventAlertFormModel } from 'form/form-models';
import { IWeatherEventAlertWebModel } from 'communication/web-models';

@Injectable()
export class WeatherEventAlertMapper extends BaseMapper<IWeatherEventAlertWebModel, WeatherEventAlert, IWeatherEventAlertFormModel> {
  constructor(
    formBuilder: FormBuilder,
    protected readonly weatherEventMapper: WeatherEventMapper,
    protected readonly weatherAlertMapper: WeatherAlertMapper,
    protected readonly weatherAlertModifierMapper: WeatherAlertModifierMapper
  ) {
    super(formBuilder);
  }
  
  public toWebModel(presentationModel: WeatherEventAlert): IWeatherEventAlertWebModel
  {
    return {
      id: presentationModel.id,
      event: presentationModel.event ? this.weatherEventMapper.toWebModel(presentationModel.event) : undefined,
      alert: this.weatherAlertMapper.toWebModel(presentationModel?.alert),
      issuanceTime: presentationModel.issuanceTime,
      modifiers: presentationModel.modifiers.map(m => this.weatherAlertModifierMapper.toWebModel(m))
    };
  }

  public toPresentationModel(formModel: IWeatherEventAlertFormModel): WeatherEventAlert {
    return new WeatherEventAlert(
      formModel.alert.value,
      formModel.issuanceTime.value,
      formModel.modifiers.value
    );
  }

  public toFormModel(presentationModel: WeatherEventAlert): IWeatherEventAlertFormModel {
    return {
      alert: this.formBuilder.nonNullable.control(presentationModel.alert, Validators.required),
      issuanceTime: this.formBuilder.nonNullable.control(presentationModel.issuanceTime, Validators.required),
      modifiers: this.formBuilder.nonNullable.array(presentationModel.modifiers.map(m => this.formBuilder.nonNullable.control(m, Validators.required)))
    };
  }
}
