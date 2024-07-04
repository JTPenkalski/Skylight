import { date } from 'shared/services';
import { GetAllWeatherEventsResponse } from 'web/clients';

export class WeatherEventSummary {
  constructor(
    public id: string,
    public name: string,
    public description: string,
    public startDate: Date,
    public tags: string[],
    public endDate?: Date,
    public damageCost?: number,
    public affectedPeople?: number,
  ) {}

  public static fromApi(data: GetAllWeatherEventsResponse): WeatherEventSummary[] {
    return (
      data.weatherEvents?.map(
        (x) =>
          new WeatherEventSummary(
            x.id!,
            x.name!,
            x.description!,
            date(x.startDate)!,
            x.tags!,
            date(x.endDate),
            x.damageCost,
            x.affectedPeople,
          ),
      ) ?? []
    );
  }
}
