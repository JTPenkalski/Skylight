import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

export type AddTagData = {
  name: string;
}

export class AddTag {
  public readonly name: FormControl<string>;

  constructor(formBuilder: FormBuilder, data?: AddTagData) {
    this.name = formBuilder.nonNullable.control(data?.name ?? '', Validators.required);
  }

  public static toFormGroup(formBuilder: FormBuilder, data?: AddTagData): FormGroup<AddTag> {
    return formBuilder.group(new AddTag(formBuilder, data));
  }

  public static fromFormGroup(formGroup: FormGroup<AddTag>): AddTagData {
    return formGroup.getRawValue();
  }
}
