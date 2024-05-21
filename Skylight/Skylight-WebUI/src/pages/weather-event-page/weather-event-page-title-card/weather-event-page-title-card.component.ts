import { Component } from '@angular/core';
import { NbBadgeModule, NbButtonModule, NbCardModule, NbIconModule, NbTooltipModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { DatePipe } from '@angular/common';
import { IconCardComponent, TabContainerComponent } from 'components';

@Component({
  selector: 'skylight-weather-event-page-title-card',
  standalone: true,
  imports: [
    NbBadgeModule,
    NbButtonModule,
    NbCardModule,
    NbEvaIconsModule,
    NbIconModule,
    NbTooltipModule,
    TabContainerComponent,
    IconCardComponent,
    DatePipe,
  ],
  templateUrl: './weather-event-page-title-card.component.html',
  styleUrl: './weather-event-page-title-card.component.scss'
})
export class WeatherEventPageTitleCardComponent {
  public title: string = 'Tornado Outbreak of April 26-28, 2024';
  public description: string = 'From April 26–28, 2024, a very large, deadly and destructive tornado outbreak occurred across the Midwestern, Southern, and High Plains regions of the United States, primarily on April 26 and 27.[2] The Storm Prediction Center (SPC) first issued an enhanced risk for the Plains on April 26, as a broad upper-trough moved eastwards, with tornadic activity erupted in the states of Iowa and Kansas that evening. A moderate risk was issued by the SPC on April 27 for areas further south in Oklahoma, where a deadly nocturnal event unfolded with many supercell thunderstorms and tornadoes tracking over towns several times. Millions were put under a particularly dangerous situation (PDS) tornado watch on April 27, and several PDS tornado warnings were issued that night as numerous strong tornadoes touched down. The outbreak served as the beginning of a broader 16-day period of constant severe weather and tornado activity across the United States that would continue until May 10.';
  public startDate: Date = new Date(2024, 3, 26);
  public endDate?: Date;// = new Date(2024, 3, 28);
  public damageCost?: string = "$1.8 Billion";
  public affectedPeople?: number = 8;

  get isActive(): boolean { return !this.endDate; }
}
