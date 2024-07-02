import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { NbButtonModule, NbCardModule, NbInputModule } from '@nebular/theme';
import { AddTag, AddTagData } from 'pages/weather-event-page/forms';
import { WeatherEventService } from 'pages/weather-event-page/services';

@Component({
  selector: 'skylight-weather-event-add-tag-window',
  standalone: true,
  imports: [NbCardModule, NbButtonModule, NbInputModule, ReactiveFormsModule],
  templateUrl: './weather-event-add-tag-window.component.html',
  styleUrl: './weather-event-add-tag-window.component.scss',
})
export class WeatherEventAddTagWindowComponent {
  @Input({ required: true })
  public weatherEventId: string = '';

  @Output()
  public tagAdded: EventEmitter<boolean> = new EventEmitter<boolean>();

  public form: FormGroup<AddTag> = AddTag.toFormGroup(this.formBuilder);

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly service: WeatherEventService,
  ) {}

  public addTag(): void {
    if (!this.form.valid) return;

    const addTag: AddTagData = AddTag.fromFormGroup(this.form);

    this.service
      .addTag(this.weatherEventId, addTag.name)
      .subscribe((result) => this.tagAdded.emit(result));
  }
}
