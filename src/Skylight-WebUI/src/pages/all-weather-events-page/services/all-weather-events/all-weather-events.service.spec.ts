import { TestBed } from '@angular/core/testing';

import { AllWeatherEventsService } from './all-weather-events.service';

describe('AllWeatherEventsService', () => {
  let service: AllWeatherEventsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AllWeatherEventsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
