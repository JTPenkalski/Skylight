import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { DynamicFormCreatorService } from 'src/services/dynamic-forms/dynamic-form-creator.service';
import { DynamicFormLoaderService } from 'src/services/dynamic-forms/dynamic-form-loader.service';
import { Form } from 'src/services/dynamic-forms/forms/form';

@Component({
  selector: 'dynamic-form',
  templateUrl: './dynamic-form.component.html',
  styleUrls: ['./dynamic-form.component.scss']
})
export class DynamicFormComponent implements OnInit {
  @Input() public formTemplate!: string;

  public form!: Form;
  public model!: FormGroup;

  constructor(
    protected dynamicFormLoader: DynamicFormLoaderService,
    protected dynamicFormCreator: DynamicFormCreatorService
  ) { }

  public ngOnInit(): void {
    this.form = this.dynamicFormLoader.loadForm(this.formTemplate);
    this.model = this.dynamicFormCreator.createFormModel(this.form);
  }

  protected onSubmit(): void {
    
  }
}
