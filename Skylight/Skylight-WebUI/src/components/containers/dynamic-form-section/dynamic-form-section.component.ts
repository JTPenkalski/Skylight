import { Component, ComponentRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { Form } from 'src/services/dynamic-forms/forms/form';
import { Section } from 'src/services/dynamic-forms/sections/section';
import { DynamicFormQuestionComponent, DynamicFormQuestionDirective } from 'src/components/controls/dynamic-forms/dynamic-form-question/dynamic-form-question.component';

@Component({
  selector: 'dynamic-form-section',
  templateUrl: './dynamic-form-section.component.html',
  styleUrls: ['./dynamic-form-section.component.scss']
})
export class DynamicFormSectionComponent implements OnInit {
  @Input() public section!: Section;
  @Input() public form!: Form;
  @Input() public model!: FormGroup;
  @ViewChild(DynamicFormQuestionDirective, { static: true }) protected dynamicQuestionContainer!: DynamicFormQuestionDirective;

  public get control(): FormGroup { return this.model.get(this.section.id) as FormGroup; }

  public ngOnInit(): void {
    this.initQuestions();
  }

  protected initQuestions(): void {
    this.section.questions.forEach(question => {
      const dynamicQuestionInstance: ComponentRef<DynamicFormQuestionComponent> =
        this.dynamicQuestionContainer.viewContainer.createComponent<DynamicFormQuestionComponent>(question.dynamicComponent);

        dynamicQuestionInstance.instance.question = question;
        dynamicQuestionInstance.instance.section = this.section;
        dynamicQuestionInstance.instance.model = this.model;
    });
  }
}
