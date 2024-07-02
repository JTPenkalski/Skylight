import {
  ComponentFixture,
  TestBed,
} from '@angular/core/testing';

import { WeatherEventAlertButtonComponent } from './weather-event-alert-button.component';

describe('WeatherEventAlertButtonComponent', () => {
  let component: WeatherEventAlertButtonComponent;
  let fixture: ComponentFixture<WeatherEventAlertButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeatherEventAlertButtonComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(
      WeatherEventAlertButtonComponent,
    );
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
