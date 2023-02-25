import { IRequestor } from "./requestor-interface.requestor";
import { Weather } from "core/models";

export interface IWeatherRequestor extends IRequestor<Weather> {
  
}
