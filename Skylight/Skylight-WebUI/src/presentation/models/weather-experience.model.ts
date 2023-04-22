import { BaseModel } from './index';
import { IWeatherExperience as IWeatherExperienceWebModel } from 'web/web-models';

export interface IWeatherExperience extends IWeatherExperienceWebModel {
  // Add any Presentation Layer data fields here...
}

export class WeatherExperience extends BaseModel implements IWeatherExperience {
  public name: string;
  public description: string;
  public startTime: Date;
  public endTime?: Date;

  constructor(data?: IWeatherExperience) {
    super(data);

    this.name = this.str(data?.name);
    this.description = this.str(data?.description);
    this.startTime = this.date(data?.startTime);
    this.endTime = this.date(data?.endTime);
  }
}
