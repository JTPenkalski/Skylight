import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherEventLocationsCardComponent } from './weather-event-locations-card.component';

describe('WeatherEventLocationsCardComponent', () => {
  let component: WeatherEventLocationsCardComponent;
  let fixture: ComponentFixture<WeatherEventLocationsCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeatherEventLocationsCardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WeatherEventLocationsCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
