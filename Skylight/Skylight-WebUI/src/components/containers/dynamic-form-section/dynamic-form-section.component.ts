import { AfterViewInit, Component, ComponentRef, Input, QueryList, ViewChildren } from '@angular/core';
import { ControlContainer, FormControl, FormGroup } from '@angular/forms';

import { Section } from '../../../services/dynamic-forms/sections/section';
import { DynamicFormQuestionComponent, DynamicFormQuestionDirective } from '../../controls/dynamic-forms/dynamic-form-question/dynamic-form-question.component';

@Component({
  selector: 'dynamic-form-section',
  templateUrl: './dynamic-form-section.component.html',
  styleUrls: ['./dynamic-form-section.component.scss']
})
export class DynamicFormSectionComponent implements AfterViewInit {
  @Input() public section!: Section;
  @ViewChildren(DynamicFormQuestionDirective) protected dynamicQuestions!: QueryList<DynamicFormQuestionDirective>;

  public get formGroup(): FormGroup { return this.parent.control as FormGroup; }

  constructor(protected parent: ControlContainer) { }

  public ngAfterViewInit(): void {
    this.loadQuestions();
  }

  protected loadQuestions(): void {
    this.dynamicQuestions.forEach((dynamicQuestion, index) => {
      const dynamicQuestionInstance: ComponentRef<DynamicFormQuestionComponent> =
        dynamicQuestion.viewContainer.createComponent<DynamicFormQuestionComponent>(this.section.questions[index].dynamicComponent);

      dynamicQuestionInstance.instance.question = this.section.questions[index];
      //dynamicQuestionInstance.instance.formControl = this.formGroup.get(this.section.questions[index].key) as FormControl;
    });
  }
}
