import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherEventPageCardContainerComponent } from './weather-event-page-card-container.component';

describe('WeatherEventPageCardContainerComponent', () => {
  let component: WeatherEventPageCardContainerComponent;
  let fixture: ComponentFixture<WeatherEventPageCardContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeatherEventPageCardContainerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WeatherEventPageCardContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
