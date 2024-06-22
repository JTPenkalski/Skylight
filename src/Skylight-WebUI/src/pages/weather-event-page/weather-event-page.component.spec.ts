import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherEventPageComponent } from './weather-event-page.component';

describe('WeatherEventPageComponent', () => {
  let component: WeatherEventPageComponent;
  let fixture: ComponentFixture<WeatherEventPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeatherEventPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WeatherEventPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
