import * as SignalR from "@microsoft/signalr"
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';

/**
 * Connection hub between client/server for Weather Event events.
 * NOTE: SignalR connections may be closed due to browser sleep/inactivity. Maybe investigate some ways to prevent this, if needed?
 */
@Injectable({
  providedIn: 'root'
})
export class WeatherEventHubConnectionService {
  private readonly ReceivePrefix: string = 'Receive';

  private hubConnection?: SignalR.HubConnection;

  /**
   * Opens a connection to the SignalR Hub.
   * This should only be called once by the aggregate page.
   */
  public connect(): void {
    const hubUrl = `${environment.skylightApiUrl}/hub/weather-event`;
    
    this.hubConnection = new SignalR.HubConnectionBuilder()
      .withUrl(hubUrl)
      .withAutomaticReconnect()
      .configureLogging(SignalR.LogLevel.Information)
      .build();

    this.hubConnection.start()
      .then(() => console.log(`Successfully connected to SignalR Hub at ${hubUrl}.`))
      .catch(error => console.error(`Error connecting to SignalR Hub at ${hubUrl}: ${error}`));

    this
      .addReconnecting()
      .addClose()
      .addNewWeatherAlerts();
  }

  /**
   * Closes the connection to the SignalR Hub.
   */
  public disconnect(): void {
    this.hubConnection?.stop();
  }

  protected addClose(): WeatherEventHubConnectionService {
    this.hubConnection?.onclose(error => {
      console.error(`Weather Event Hub closing. Potential error: ${error}`);

      // TODO: Emit signal?
    });

    return this;
  }

  protected addReconnecting(): WeatherEventHubConnectionService {
    this.hubConnection?.onreconnecting(error => {
      console.error(`Weather Event Hub reconnecting from error: ${error}`);

      // TODO: Emit signal?
    });

    return this;
  }

  protected addNewWeatherAlerts(): WeatherEventHubConnectionService {
    this.hubConnection?.on(`${this.ReceivePrefix}NewWeatherAlerts`, (data: string) => {
      console.log('Received message from server: ' + data);
      // TODO: Emit signal?
    });

    return this;
  }
}
