import { AbstractControl, FormControl } from '@angular/forms';

// Note: Form models (subclasses of this BaseModel) can import either from
//       this directory (./index) or the presentation layer. Import from
//       this directory if you need a FormGroup with nested controls. Import from
//       the presentation layer if a simple FormControl of a complex type will suffice.

export interface IBaseModel extends Record<string, AbstractControl> {
  readonly deleted: FormControl<boolean>;
}

/**
 * Base form model for all input logic within the Skylight Web UI.
 * It allows the Input Layer to have an independent interface for form logic.
 **/
export abstract class BaseModel implements IBaseModel {
  [key: string]: AbstractControl;
  public readonly deleted: FormControl<boolean> = new FormControl<boolean>(false, { nonNullable: true }); // May or may not be used, but required for type definition
}
