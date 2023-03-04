import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { BaseModel } from 'core/models';
import { IBaseFormModel } from 'display/input/form-models';

@Injectable()
export abstract class BaseFormMapper<TPresentationModel extends BaseModel, TFormModel extends IBaseFormModel> {
  constructor(protected readonly formBuilder: FormBuilder) { }

  public abstract toPresentationModel(source: TFormModel): TPresentationModel;

  public abstract toFormModel(source: TPresentationModel): TFormModel;
}
