import { TestBed } from '@angular/core/testing';

import { WeatherEventHubConnectionService } from './weather-event-hub-connection.service';

describe('WeatherEventHubConnectionService', () => {
  let service: WeatherEventHubConnectionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WeatherEventHubConnectionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
