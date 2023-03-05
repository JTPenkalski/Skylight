import { FormControl } from '@angular/forms';

/**
 * SkylightFormQuestionComponents rely on having a parent FormGroup component.
 * Therefore, when using a FormArray in a Form Model, this type is used if there is no explicit Form Model.
 * (Otherwise, an ordinary 'FormGroup<IFormModel>' could be used.)
 * This implies that a complex type is filled in with a single control, like a dropdown, rather than a full form with multiple controls.
 * So, when there is a FormArray of form models, it would be the normal 'FormArray<FormGroup<IFormModel>>'.
 * But, when there is a FormArray of view models, it would be 'FormArray<FormGroup<FormArrayControl<Model>>>'.
 **/
export type FormArrayControl<T> = {
  control: FormControl<T>;
};