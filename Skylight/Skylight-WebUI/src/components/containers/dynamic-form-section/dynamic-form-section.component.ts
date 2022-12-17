import { AfterViewInit, ChangeDetectorRef, Component, ComponentRef, Input, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { ControlContainer, FormControl, FormGroup } from '@angular/forms';

import { Form } from '../../../services/dynamic-forms/forms/form';
import { Section } from '../../../services/dynamic-forms/sections/section';
import { DynamicFormQuestionComponent, DynamicFormQuestionDirective } from '../../controls/dynamic-forms/dynamic-form-question/dynamic-form-question.component';

@Component({
  selector: 'dynamic-form-section',
  templateUrl: './dynamic-form-section.component.html',
  styleUrls: ['./dynamic-form-section.component.scss']
})
export class DynamicFormSectionComponent implements OnInit, AfterViewInit {
  @Input() public section!: Section;
  @Input() public form!: Form;
  //@ViewChildren(DynamicFormQuestionDirective) protected dynamicQuestions!: QueryList<DynamicFormQuestionDirective>;
  @ViewChild(DynamicFormQuestionDirective, { static: true }) protected dynamicQuestionContainer!: DynamicFormQuestionDirective;

  public get group(): FormGroup { return this.parent.control as FormGroup; }
  public get control(): FormGroup { return this.group.get(this.section.id) as FormGroup; }

  constructor(protected parent: ControlContainer, protected changeDetector: ChangeDetectorRef) { }

  public ngOnInit(): void {
    console.log('---SECTION INIT---');
    this.initSection();
    this.initQuestions();
  }

  public ngAfterViewInit(): void {
  //  console.log('---SECTION AFTER_INIT---' + this.section.id);
  //  this.initQuestions();

  //  // Manually detect changes, because the parent state has been updated from this child
  //  this.changeDetector.detectChanges();
  }

  protected initSection(): void {
    const q = new FormGroup(this.section.questions.reduce((questionAccumulator, question) => {
      return {
        ...questionAccumulator,
        [question.id]: new FormControl(question.value || '', question.validators.map(v => v.getValidator()))
      }
    }, {}))
    this.group.addControl(this.section.id, q);

    console.log('NEW GROUP:')
    console.log(q);

    console.log('MASTER FORM GROUP:')
    console.log(this.group);
  }

  protected initQuestions(): void {
    //this.dynamicQuestions.forEach((dynamicQuestion, index) => {
    //  const dynamicQuestionInstance: ComponentRef<DynamicFormQuestionComponent> =
    //    dynamicQuestion.viewContainer.createComponent<DynamicFormQuestionComponent>(this.section.questions[index].dynamicComponent);

    //  dynamicQuestionInstance.instance.section = this.section;
    //  dynamicQuestionInstance.instance.question = this.section.questions[index];
    //  dynamicQuestionInstance.instance.formGroup = this.group;
    //});

    this.section.questions.forEach(question => {
      const dynamicQuestionInstance: ComponentRef<DynamicFormQuestionComponent> =
        this.dynamicQuestionContainer.viewContainer.createComponent<DynamicFormQuestionComponent>(question.dynamicComponent);

        dynamicQuestionInstance.instance.section = this.section;
        dynamicQuestionInstance.instance.question = question;
        dynamicQuestionInstance.instance.formGroup = this.group;
    });
  }
}
