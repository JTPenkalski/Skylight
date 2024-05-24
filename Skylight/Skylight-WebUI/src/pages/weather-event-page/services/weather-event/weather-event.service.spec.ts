import { TestBed } from '@angular/core/testing';

import { WeatherEventService } from './weather-event.service';

describe('WeatherEventService', () => {
  let service: WeatherEventService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WeatherEventService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
