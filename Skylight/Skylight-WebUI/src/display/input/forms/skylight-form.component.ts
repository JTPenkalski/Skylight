import { Directive, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { IService } from 'core/services';
import { IBaseModel as IBaseCoreModel } from 'presentation/models';
import { IBaseModel } from '../models';

/**
 * Base Form for all model forms.
 **/
@Directive()
export abstract class SkylightFormComponent<TModel extends IBaseCoreModel, TFormModel extends IBaseModel> implements OnInit {
  @Input() public model!: TModel;

  public form!: FormGroup<TFormModel>;

  constructor(
    protected readonly formBuilder: FormBuilder,
    protected readonly service: IService<TModel>
  ) { }

  public abstract ngOnInit(): void;

  /**
   * Submits the form to the server.
   **/
  public abstract submit(): void;
}
