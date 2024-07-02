import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherEventCardComponent } from './weather-event-card.component';

describe('WeatherEventCardComponent', () => {
  let component: WeatherEventCardComponent;
  let fixture: ComponentFixture<WeatherEventCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeatherEventCardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WeatherEventCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
