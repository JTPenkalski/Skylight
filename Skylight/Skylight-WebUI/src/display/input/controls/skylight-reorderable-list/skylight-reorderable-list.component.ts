import { Component, ContentChild, EventEmitter, Input, Output } from '@angular/core';
import { AbstractControl, FormArray, FormGroup } from '@angular/forms';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

import { SkylightReorderableListItemDirective } from './skylight-reorderable-list-item.directive';
import { IAbstractControlInstance } from '../skylight-form-questions/types';

@Component({
  selector: 'skylight-reorderable-list',
  templateUrl: './skylight-reorderable-list.component.html',
  styleUrls: ['./skylight-reorderable-list.component.scss']
})
export class SkylightReorderableListComponent {
  @Output() public itemAdded: EventEmitter<undefined> = new EventEmitter<undefined>();
  @Output() public itemRemoved: EventEmitter<number> = new EventEmitter<number>();
  
  @Input() public instance: IAbstractControlInstance = { name: '', control: new FormArray([]) };
  @ContentChild(SkylightReorderableListItemDirective) public content!: SkylightReorderableListItemDirective;

  /**
   * The key of the AbstractControl within a FormGroup.
   * Could be a number if based on the index within a FormArray.
   **/
  public get name(): string | number { return this.instance.name; }

  /**
   * The collection of FormGroup controls within this array.
   **/
  public get items(): FormGroup[] { return (this.instance.control as FormArray<FormGroup>).controls; }

  /**
   * The actual AbstractControl within a FormGroup.
   **/
  public get control(): AbstractControl { return this.instance.control; }

  /**
   * The parent of the AbstractControl.
   **/
  public get parent(): FormGroup { return this.control.parent as FormGroup; }

  /**
   * Generates the ngTemplateContext object to be used by client component HTML templates.
   * @param item The current item being rendered within the array.
   * @param index The index of the current item being rendered within the array.
   * @returns An object with the specified item and index properties.
   **/
  public context(item: FormGroup, index: number): { item: FormGroup, index: number } {
    return {
      item: item,
      index: index
    };
  }

  /**
   * Called when an draggable item is dropped back into the array.
   * @param event The event payload.
   **/
  public drop(event: CdkDragDrop<any>): void {
    moveItemInArray(this.items, event.previousIndex, event.currentIndex);
  }

  /**
   * Called when an item is added to the array. Invokes the related event.
   **/
  public onItemAdded(): void {
    this.itemAdded.emit();
  }

  /**
   * Called when an item is removed from the array. Invokes the related event.
   * @param index The index of the removed item.
   **/
  public onItemRemoved(index: number): void {
    this.itemRemoved.emit(index);
  }
}
