import { ElementRef } from '@angular/core';
import { DarkenDirective } from './darken.directive';

describe('DarkenDirective', () => {
  it('should create an instance', () => {
    const directive = new DarkenDirective(new ElementRef(null));
    expect(directive).toBeTruthy();
  });
});
