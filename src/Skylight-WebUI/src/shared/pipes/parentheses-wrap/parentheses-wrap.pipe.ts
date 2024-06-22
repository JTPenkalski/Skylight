import { Pipe, PipeTransform } from '@angular/core';

/**
 * Adds parentheses around a value, if it exists.
 */
@Pipe({
  name: 'parenthesesWrap',
  standalone: true
})
export class ParenthesesWrapPipe implements PipeTransform {
  public transform(value: any): string {
    return !!value ? `(${value})` : '';
  }
}
