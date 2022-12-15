import { Component, ComponentRef, Input, OnInit, ViewChild, ViewContainerRef } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import { DynamicFormLoaderService } from '../../../services/dynamic-forms/dynamic-form-loader.service';
import { Form } from '../../../services/dynamic-forms/forms/form';
import { DynamicFormQuestionComponent } from '../../controls/dynamic-forms/dynamic-form-question/dynamic-form-question.component';

@Component({
  selector: 'dynamic-form',
  templateUrl: './dynamic-form.component.html',
  styleUrls: ['./dynamic-form.component.scss']
})
export class DynamicFormComponent implements OnInit {
  @Input() public formTemplate!: string;
  @ViewChild('questions', { static: true }) protected dynamicQuestions!: ViewContainerRef;

  public formGroup!: FormGroup;

  constructor(protected dynamicFormLoader: DynamicFormLoaderService) { }

  public ngOnInit(): void {
    this.loadForm();
  }

  protected onSubmit(): void {
    console.log('Form submitted!');
  }

  protected loadForm(): void {
    const form: Form = this.dynamicFormLoader.loadForm(this.formTemplate);

    this.loadQuestions(form);
    this.loadFormGroup(form);
  }

  protected loadFormGroup(form: Form): void {
    const group: any = {};

    form.questions.forEach(question => {
      group[question.key] = new FormControl(question.value || '', question.validators.map(v => v.getValidator()));
    });

    this.formGroup = new FormGroup(group);
  }

  protected loadQuestions(form: Form): void {
    this.dynamicQuestions.clear();

    form.questions.forEach(question => {
      const dynamicQuestion: ComponentRef<DynamicFormQuestionComponent> = this.dynamicQuestions.createComponent<DynamicFormQuestionComponent>(question.dynamicComponent);

      dynamicQuestion.instance.formGroup = this.formGroup;
      dynamicQuestion.instance.question = question;
    });
  }
}
