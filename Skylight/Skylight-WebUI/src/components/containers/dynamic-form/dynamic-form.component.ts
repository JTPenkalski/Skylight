import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormRecord } from '@angular/forms';

import { DynamicFormLoaderService } from '../../../services/dynamic-forms/dynamic-form-loader.service';
import { Form } from '../../../services/dynamic-forms/forms/form';
import { Question } from '../../../services/dynamic-forms/questions/question';
import { Section } from '../../../services/dynamic-forms/sections/section';

@Component({
  selector: 'dynamic-form',
  templateUrl: './dynamic-form.component.html',
  styleUrls: ['./dynamic-form.component.scss']
})
export class DynamicFormComponent implements OnInit {
  @Input() public formTemplate!: string;

  public form!: Form;
  public control!: FormRecord;

  constructor(protected dynamicFormLoader: DynamicFormLoaderService) { }

  public ngOnInit(): void {
    console.log('---FORM INIT---');
    this.loadForm();
    this.initForm();
  }

  protected onSubmit(): void {
    console.log('FORM GROUP:');
    console.log(this.control);
  }

  protected loadForm(): void {
    this.form = this.dynamicFormLoader.loadForm(this.formTemplate);
  }

  protected initForm(): void {
    this.control = new FormRecord<AbstractControl<Section>>(this.form.sections.reduce((sectionAccumulator, section) => {
      return {
        ...sectionAccumulator,
        [section.id]: new FormRecord<AbstractControl<Question>>({})
      }
    }, {}));
  }
}
