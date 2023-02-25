import { BaseRequestor } from "./base-requestor.requestor";
import { IWeatherRequestor } from "core/requestors";
import { IHttpControllerClient } from "core/services";
import { Weather } from "core/models";

export class WeatherRequestor extends BaseRequestor<Weather> implements IWeatherRequestor {
  public override get controller(): string { return Weather.name; }

  constructor(client: IHttpControllerClient<Weather>) { 
    super(client);
    this.client.endpoint = this.controller;
  }
}
