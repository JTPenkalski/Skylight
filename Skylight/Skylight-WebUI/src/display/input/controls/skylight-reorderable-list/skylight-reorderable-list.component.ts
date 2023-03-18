import { Component, ContentChild, EventEmitter, Input, Output } from '@angular/core';
import { AbstractControl, FormArray, FormGroup } from '@angular/forms';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

import { SkylightReorderableListItemDirective } from './skylight-reorderable-list-item.directive';
import { IAbstractControlInstance } from '../skylight-form-questions/models';

@Component({
  selector: 'skylight-reorderable-list',
  templateUrl: './skylight-reorderable-list.component.html',
  styleUrls: ['./skylight-reorderable-list.component.scss']
})
export class SkylightReorderableListComponent {
  @Output() public itemAdded: EventEmitter<undefined> = new EventEmitter<undefined>();
  @Output() public itemRemoved: EventEmitter<number> = new EventEmitter<number>();
  
  @Input() public instance: IAbstractControlInstance = { name: '', control: new FormArray([]) };
  @ContentChild(SkylightReorderableListItemDirective) content!: SkylightReorderableListItemDirective;

  public get name(): string | number { return this.instance.name; }
  public get items(): FormGroup[] { return (this.instance.control as FormArray<FormGroup>).controls; }
  public get control(): AbstractControl { return this.instance.control; }
  public get parent(): FormGroup { return this.control.parent as FormGroup; }

  public context(item: FormGroup, index: number): { item: FormGroup, index: number } {
    return {
      item: item,
      index: index
    };
  }

  public drop(event: CdkDragDrop<any>): void {
    moveItemInArray(this.items, event.previousIndex, event.currentIndex);
  }

  public add(): void {
    this.itemAdded.emit();
  }

  public remove(index: number): void {
    this.itemRemoved.emit(index);
  }
}
