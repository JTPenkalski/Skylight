import {
  ComponentFixture,
  TestBed,
} from '@angular/core/testing';

import { WeatherEventAlertWindowComponent } from './weather-event-alert-window.component';

describe('WeatherEventAlertWindowComponent', () => {
  let component: WeatherEventAlertWindowComponent;
  let fixture: ComponentFixture<WeatherEventAlertWindowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeatherEventAlertWindowComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(
      WeatherEventAlertWindowComponent,
    );
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
