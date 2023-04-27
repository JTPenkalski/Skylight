import { FormGroup } from '@angular/forms';

import { ISkylightFormQuestion } from './skylight-form-question';

/**
 * A specialization of a SkylightFormQuestion that specifically handles groups of controls.
 **/
export interface ISkylightFormQuestionContainer extends ISkylightFormQuestion {
  group: FormGroup;
}