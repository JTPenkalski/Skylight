import { Directive, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { IService } from 'core/services';
import { IBaseModel as IBaseCoreModel } from 'presentation/models';
import { IBaseModel } from '../models';

/**
 * Base Form for all model forms.
 **/
@Directive()
export abstract class SkylightFormComponent<TModel extends IBaseCoreModel, TFormModel extends IBaseModel, TFormGuide> implements OnInit {
  @Input() public model!: TModel;

  public form!: FormGroup<TFormModel>;
  public guide?: TFormGuide;

  constructor(
    protected readonly formBuilder: FormBuilder,
    protected readonly service: IService<TModel, TFormGuide>
  ) { }

  public abstract ngOnInit(): void;

  /**
   * Submits the form to the server.
   **/
  public abstract submit(): void;

  /**
   * Resets the form to its default state.
   */
  public abstract reset(): void;

  /**
   * Makes a request to the server to fetch Form Guide information.
   */
  public abstract requestGuide(): void;
}
