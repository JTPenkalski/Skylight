import { FormBuilder, FormGroup } from '@angular/forms';

import { IBaseModel as IBaseCoreModel } from 'presentation/models';

export interface IBaseModel {
  
}

/**
 * Base form model for all input logic within the Skylight Web UI.
 * It allows the Input Layer to have an independent interface for form logic.
 **/
export abstract class BaseModel implements IBaseModel {
  constructor(formBuilder: FormBuilder) { }
}