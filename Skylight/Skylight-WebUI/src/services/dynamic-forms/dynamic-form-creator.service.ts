import { Injectable } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import { Form } from './forms/form';
import { Section } from './sections/section';

/**
 * Creates a Reactive Forms Model to represent a Dynamic Form.
 **/
@Injectable({
  providedIn: 'root'
})
export class DynamicFormCreatorService {
  public createFormModel(form: Form) : FormGroup {
    return new FormGroup(form.sections.reduce((sectionAccumulator, section) => {
      return {
        ...sectionAccumulator,
        [section.id]: this.createSectionModel(section)
      }
    }, {}));
  }

  public createSectionModel(section: Section) : FormGroup {
    return new FormGroup(section.questions.reduce((questionAccumulator, question) => {
      return {
        ...questionAccumulator,
        [question.id]: new FormControl(question.value || '', question.validators.map(v => v.getValidator()))
      }
    }, {}));
  }
}
