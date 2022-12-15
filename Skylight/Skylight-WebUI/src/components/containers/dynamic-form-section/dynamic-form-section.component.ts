import { Component, ComponentRef, Input, OnInit, QueryList, ViewChildren } from '@angular/core';

import { Section } from '../../../services/dynamic-forms/sections/section';
import { DynamicFormQuestionComponent, DynamicFormQuestionDirective } from '../../controls/dynamic-forms/dynamic-form-question/dynamic-form-question.component';

@Component({
  selector: 'dynamic-form-section',
  templateUrl: './dynamic-form-section.component.html',
  styleUrls: ['./dynamic-form-section.component.scss']
})
export class DynamicFormSectionComponent implements OnInit {
  @Input() public formGroupName!: string;
  @Input() public section!: Section;
  @ViewChildren(DynamicFormQuestionDirective) protected dynamicQuestions!: QueryList<DynamicFormQuestionDirective>;

  constructor() { }

  public ngOnInit(): void {
    this.loadQuestions();
  }

  protected loadQuestions(): void {
    this.dynamicQuestions.forEach((dynamicQuestion, index) => {
      const dynamicQuestionInstance: ComponentRef<DynamicFormQuestionComponent> =
        dynamicQuestion.viewContainer.createComponent<DynamicFormQuestionComponent>(this.section.questions[index].dynamicComponent);

      dynamicQuestionInstance.instance.question = this.section.questions[index];
    });
  }
}
