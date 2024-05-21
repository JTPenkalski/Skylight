import { DatePipe } from '@angular/common';
import { Component, Input } from '@angular/core';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NbCardModule, NbIconModule } from '@nebular/theme';
import { DarkenDirective } from 'directives';

@Component({
  selector: 'skylight-icon-card',
  standalone: true,
  imports: [
    NbCardModule,
    NbEvaIconsModule,
    NbIconModule,
    DarkenDirective,
    DatePipe
  ],
  templateUrl: './icon-card.component.html',
  styleUrl: './icon-card.component.scss'
})
export class IconCardComponent {
  @Input() public icon: string = 'info';
}
