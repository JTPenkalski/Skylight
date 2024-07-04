import { Component, EventEmitter, Input, Output } from '@angular/core';
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
    NoSelectDirective,
  ],
  templateUrl: './tab-container.component.html',
  styleUrl: './tab-container.component.scss',
})
export class TabContainerComponent {
  @Input()
  public tags: string[] = [];

  @Output()
  public newTagRequested: EventEmitter<void> = new EventEmitter<void>();

  public get displayTags(): string[] {
    return this.tags.sort((x, y) => x.localeCompare(y));
  }

  public get hasTags(): boolean {
    return this.tags.length > 0;
  }

  public requestNewTag(): void {
    this.newTagRequested.emit();
  }
}
