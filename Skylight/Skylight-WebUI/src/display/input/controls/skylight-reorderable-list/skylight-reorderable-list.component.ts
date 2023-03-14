import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'skylight-reorderable-list',
  templateUrl: './skylight-reorderable-list.component.html',
  styleUrls: ['./skylight-reorderable-list.component.scss']
})
export class SkylightReorderableListComponent {
  @Input() public items: any[] = [];

  public drop(event: CdkDragDrop<any>): void {
    moveItemInArray(this.items, event.previousIndex, event.currentIndex);
  }
}
