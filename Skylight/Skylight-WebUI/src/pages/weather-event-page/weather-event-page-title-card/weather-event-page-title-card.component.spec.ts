import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherEventPageTitleCardComponent } from './weather-event-page-title-card.component';

describe('WeatherEventPageTitleCardComponent', () => {
  let component: WeatherEventPageTitleCardComponent;
  let fixture: ComponentFixture<WeatherEventPageTitleCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeatherEventPageTitleCardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WeatherEventPageTitleCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
