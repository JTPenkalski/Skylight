export class WeatherEventSummary {
  constructor(
    public name: string,
    public description: string,
    public startDate: Date,
    public endDate?: Date,
    public damageCost?: number,
    public affectedPeople?: number
  ) { }
}