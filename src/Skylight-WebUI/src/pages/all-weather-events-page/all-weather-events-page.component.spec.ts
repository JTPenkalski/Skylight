import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllWeatherEventsPageComponent } from './all-weather-events-page.component';

describe('AllWeatherEventsPageComponent', () => {
  let component: AllWeatherEventsPageComponent;
  let fixture: ComponentFixture<AllWeatherEventsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AllWeatherEventsPageComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(AllWeatherEventsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
