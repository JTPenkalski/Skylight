import { Component, ContentChild, EventEmitter, Input, Output } from '@angular/core';
import { AbstractControl, FormArray, FormGroup } from '@angular/forms';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';

import { SkylightReorderableListItemDirective } from './skylight-reorderable-list-item.directive';

/**
 * A component for displaying FormArrays that allows the user to add, delete, and reorder its elements.
 * Specify a child 'ng-template' node with the 'reorderableListItem' Directive to define the view of an individual list element.
 * @requires [array]: The FormArray this component is linked to.
 * @requires [formArrayName]: The name FormArray this component is linked to. Both are needed, since a [formArray] Directive does not exist.
 **/
@Component({
  selector: 'skylight-reorderable-list[formArrayName][array]',
  templateUrl: './skylight-reorderable-list.component.html',
  styleUrls: ['./skylight-reorderable-list.component.scss']
})
export class SkylightReorderableListComponent {
  @Input() public array!: FormArray;

  @Output() public itemAdded: EventEmitter<undefined> = new EventEmitter<undefined>();
  @Output() public itemRemoved: EventEmitter<number> = new EventEmitter<number>();
  
  @ContentChild(SkylightReorderableListItemDirective) public content!: SkylightReorderableListItemDirective;

  /**
   * The collection of AbstractControls within this array.
   **/
  public get items(): AbstractControl[] { return this.array.controls; }

  /**
   * Generates the ngTemplateContext object to be used by client component HTML templates.
   * @param item The current item being rendered within the array.
   * @param index The index of the current item being rendered within the array.
   * @returns An object with the specified item and index properties.
   **/
  public context(index: number): { index: number } {
    return {
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
