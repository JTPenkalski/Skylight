import {
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  booleanAttribute,
} from '@angular/core';
import {
  NbActionsModule,
  NbCardModule,
  NbComponentSize,
  NbContextMenuModule,
  NbMenuService,
  NbSpinnerModule,
  NbTooltipModule,
} from '@nebular/theme';
import { ContextMenu } from 'shared/models';

@Component({
  selector: 'skylight-info-card',
  standalone: true,
  imports: [
    NbActionsModule,
    NbCardModule,
    NbContextMenuModule,
    NbSpinnerModule,
    NbTooltipModule,
  ],
  templateUrl: './info-card.component.html',
  styleUrl: './info-card.component.scss',
})
export class InfoCardComponent implements OnInit {
  @Input({ required: true }) public title: string = '';
  @Input({ transform: booleanAttribute })
  public noGap: boolean = false;
  @Input() public size: NbComponentSize = 'large';
  @Input() public loading: boolean = false;
  @Input() public contextMenu?: ContextMenu;

  @Output() public refresh: EventEmitter<void> =
    new EventEmitter<void>();

  constructor(private readonly menuService: NbMenuService) {}

  public get isRefreshEnabled(): boolean {
    return this.refresh.observed;
  }

  public ngOnInit(): void {
    if (this.contextMenu) {
      this.menuService
        .onItemClick()
        .subscribe((x) => this.contextMenu?.handle(x));
    }
  }

  public onRefresh(): void {
    if (this.isRefreshEnabled) {
      this.refresh.emit();
    }
  }
}
