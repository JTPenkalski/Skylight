import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherEventAlertsCardComponent } from './weather-event-alerts-card.component';

describe('WeatherEventAlertsCardComponent', () => {
  let component: WeatherEventAlertsCardComponent;
  let fixture: ComponentFixture<WeatherEventAlertsCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeatherEventAlertsCardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WeatherEventAlertsCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
