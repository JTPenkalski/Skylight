import { Component, Input } from '@angular/core';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NbButtonModule, NbCardModule, NbIconModule, NbTagModule } from '@nebular/theme';
import { NoSelectDirective } from 'shared/directives';

@Component({
  selector: 'skylight-tab-container',
  standalone: true,
  imports: [
    NbCardModule,
    NbButtonModule,
    NbIconModule,
    NbEvaIconsModule,
    NbTagModule,
    NoSelectDirective
  ],
  templateUrl: './tab-container.component.html',
  styleUrl: './tab-container.component.scss'
})
export class TabContainerComponent {
  @Input() public tags: string[] = ['Tornado', 'Outbreak', 'Oklahoma', 'PDS', 'Nocturnal', 'Iowa', 'Kansas', 'Midwest', 'South', 'High Plains'];
  
  get hasTags(): boolean { return this.tags.length > 0; }
}
