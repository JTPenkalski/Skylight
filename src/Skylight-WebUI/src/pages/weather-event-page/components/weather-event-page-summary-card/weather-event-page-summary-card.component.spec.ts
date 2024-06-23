import {
  ComponentFixture,
  TestBed,
} from '@angular/core/testing';

import { WeatherEventPageSummaryCardComponent } from './weather-event-page-summary-card.component';

describe('WeatherEventPageSummaryCardComponent', () => {
  let component: WeatherEventPageSummaryCardComponent;
  let fixture: ComponentFixture<WeatherEventPageSummaryCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeatherEventPageSummaryCardComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(
      WeatherEventPageSummaryCardComponent,
    );
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
