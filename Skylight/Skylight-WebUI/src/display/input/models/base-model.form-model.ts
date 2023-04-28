import { AbstractControl } from '@angular/forms';

export interface IBaseModel extends Record<string, AbstractControl> {
  
}

/**
 * Base form model for all input logic within the Skylight Web UI.
 * It allows the Input Layer to have an independent interface for form logic.
 **/
export abstract class BaseModel implements IBaseModel {
  [key: string]: AbstractControl;
}
