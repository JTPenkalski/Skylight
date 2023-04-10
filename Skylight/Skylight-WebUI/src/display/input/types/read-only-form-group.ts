import { FormControl, FormGroup } from '@angular/forms';

/**
 * SkylightFormQuestionComponents rely on having a parent FormGroup component.
 * 
 * This is because there is typically either the root FormGroup,
 * or simply a FormGroup for a complex type with multiple FormControls,
 * that need to be grouped together.
 * 
 * However, when using a FormArray in a Form Model, if a complex type does not need to be mapped to individual FormControls,
 * this type is used to represent that complex type in the Form Model. (Otherwise, an ordinary 'FormGroup<IFormModel>' could be used.)
 * 
 * This implies that a complex type is filled in with a single control, like a dropdown, rather than a full form with multiple controls.
 * So, when there is a FormArray of form models, it would be the normal 'FormArray<FormGroup<IFormModel>>'.
 * But, when there is a FormArray of view models, it would be 'FormArray<ReadOnlyFormGroup<<Model>>'.
 **/
type ReadOnlyFormControl<T> = {
  control: FormControl<T>;
};

export type ReadOnlyFormGroup<T> = FormGroup<ReadOnlyFormControl<T>>;