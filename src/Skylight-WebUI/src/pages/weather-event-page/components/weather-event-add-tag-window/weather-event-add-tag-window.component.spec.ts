import {
  ComponentFixture,
  TestBed,
} from '@angular/core/testing';

import { WeatherEventAddTagWindowComponent } from './weather-event-add-tag-window.component';

describe('WeatherEventAddTagWindowComponent', () => {
  let component: WeatherEventAddTagWindowComponent;
  let fixture: ComponentFixture<WeatherEventAddTagWindowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WeatherEventAddTagWindowComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(
      WeatherEventAddTagWindowComponent,
    );
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
