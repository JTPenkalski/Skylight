import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'parenthesesWrap',
  standalone: true
})
export class ParenthesesWrapPipe implements PipeTransform {
  public transform(value: any): string {
    return !!value ? `(${value})` : '';
  }
}
