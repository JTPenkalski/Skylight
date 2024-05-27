import { WeatherAlertLevel } from '.';

export class NewWeatherEventAlert {
  constructor(
    public sender: string,
    public headline: string,
    public instruction: string,
    public description: string,
    public sent: Date,
    public effective: Date,
    public expires: Date,
    public name: string,
    public source: string,
    public level: WeatherAlertLevel,
    public code?: string 
  ) { }
}
