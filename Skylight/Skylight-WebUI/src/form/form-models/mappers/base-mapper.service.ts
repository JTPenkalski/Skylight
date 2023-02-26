import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { BaseModel } from 'core/models';
import { IBaseFormModel } from 'form/form-models';

@Injectable()
export abstract class BaseMapper<TPresentationModel extends BaseModel, TFormModel extends IBaseFormModel> {
  constructor(protected readonly formBuilder: FormBuilder) { }

  public abstract toPresentationModel(formModel: TFormModel): TPresentationModel;

  public abstract toFormModel(presentationModel?: TPresentationModel): TFormModel;
}
