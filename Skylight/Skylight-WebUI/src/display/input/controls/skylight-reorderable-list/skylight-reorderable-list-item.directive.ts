import { Directive, TemplateRef } from '@angular/core';

@Directive({
  selector: '[reorderableListItem]'
})
export class SkylightReorderableListItemDirective {
  public get template(): TemplateRef<unknown> { return this.templateRef; }

  constructor(private templateRef: TemplateRef<unknown>) { }
}
