import { Directive, ElementRef } from '@angular/core';

/**
 * Automatically applies the 'darken' CSS class to make the component a darker variant.
 */
@Directive({
  selector: '[darken]',
  standalone: true,
})
export class DarkenDirective {
  constructor(element: ElementRef) {
    element.nativeElement.classList.add('darken');
  }
}
