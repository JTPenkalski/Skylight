import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { IDisplayMapper } from 'core/mappings';
import { BaseModel } from 'presentation/models';
import { IBaseFormModel } from 'display/input/form-models';

@Injectable()
export abstract class BaseFormMapper<TPresentationModel extends BaseModel, TFormModel extends IBaseFormModel> implements IDisplayMapper<TPresentationModel, TFormModel> {
  constructor(protected readonly formBuilder: FormBuilder) { }

  public abstract toPresentationModel(source: TFormModel): TPresentationModel;

  public abstract toDisplayModel(source: TPresentationModel): TFormModel;
}
