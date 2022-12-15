import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import { DynamicFormLoaderService } from '../../../services/dynamic-forms/dynamic-form-loader.service';
import { Form } from '../../../services/dynamic-forms/forms/form';

@Component({
  selector: 'dynamic-form',
  templateUrl: './dynamic-form.component.html',
  styleUrls: ['./dynamic-form.component.scss']
})
export class DynamicFormComponent implements OnInit {
  @Input() public formTemplate!: string;

  public form!: Form;
  public formGroup!: FormGroup;

  constructor(protected dynamicFormLoader: DynamicFormLoaderService) { }

  public ngOnInit(): void {
    this.loadForm();
    this.loadFormGroup();
  }

  protected onSubmit(): void {
    console.log('Form submitted!');
  }

  protected loadForm(): void {
    this.form = this.dynamicFormLoader.loadForm(this.formTemplate);
  }

  protected loadFormGroup(): void {
    this.formGroup = new FormGroup(this.form.sections.reduce((sectionAccumulator, section) => {
      return {
        ...sectionAccumulator,
        [section.key]: new FormGroup(section.questions.reduce((questionAccumulator, question) => {
          return {
            ...questionAccumulator,
            [question.key]: new FormControl(question.value || '', question.validators.map(v => v.getValidator()))
          };
          }, {})
        )
      }
    }, {}));
  }
}
