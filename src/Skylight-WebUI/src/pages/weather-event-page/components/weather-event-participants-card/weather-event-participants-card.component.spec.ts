import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherEventParticipantsCardComponent } from './weather-event-participants-card.component';

describe('WeatherEventParticipantsCardComponent', () => {
  let component: WeatherEventParticipantsCardComponent;
  let fixture: ComponentFixture<WeatherEventParticipantsCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeatherEventParticipantsCardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WeatherEventParticipantsCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
