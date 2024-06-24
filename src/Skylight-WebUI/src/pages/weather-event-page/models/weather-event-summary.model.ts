import { date } from 'shared/services';
import { GetWeatherEventByIdResponse } from 'web/clients';

export class WeatherEventSummary {
  constructor(
    public name: string,
    public description: string,
    public startDate: Date,
    public tags: string[],
    public endDate?: Date,
    public damageCost?: number,
    public affectedPeople?: number,
  ) {}

  public static fromApi(
    data: GetWeatherEventByIdResponse,
  ): WeatherEventSummary {
    return new WeatherEventSummary(
      data.name!,
      data.description!,
      date(data.startDate)!,
      data.tags ?? [],
      date(data.endDate),
      data.damageCost,
      data.affectedPeople,
    );
  }
}
