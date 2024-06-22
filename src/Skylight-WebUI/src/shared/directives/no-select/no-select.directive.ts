import { Directive, HostListener } from '@angular/core';
import { NbTagComponent } from '@nebular/theme';

/**
 * Prevents a Tag element from being actively selected.
 */
@Directive({
  selector: 'nb-tag[noSelect]',
  standalone: true
})
export class NoSelectDirective {
  constructor(private readonly tag: NbTagComponent) { }

  @HostListener('click')
  onClick(): void {
    // TODO: Revisit, since this doesn't work...
    this.tag.selected = false;
  }
}
