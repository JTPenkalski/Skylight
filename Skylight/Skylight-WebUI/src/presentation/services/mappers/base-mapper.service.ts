import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { BaseModel } from 'core/models';
import { IBaseWebModel } from 'communication/web-models';
import { IBaseFormModel } from 'form/form-models';

@Injectable()
export abstract class BaseMapper<TWebModel extends IBaseWebModel, TPresentationModel extends BaseModel, TFormModel extends IBaseFormModel> {
  constructor(protected readonly formBuilder: FormBuilder) { }

  // TODO: Use AutoMapper TS?
  public abstract toWebModel(presentationModel: TPresentationModel) : TWebModel;

  public abstract toPresentationModel(formModel: TFormModel): TPresentationModel;

  public abstract toFormModel(presentationModel: TPresentationModel): TFormModel;
}
