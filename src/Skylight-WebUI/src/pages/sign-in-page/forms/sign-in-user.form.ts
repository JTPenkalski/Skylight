import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';

export type SignInUserData = {
  email: string;
  password: string;
};

export class SignInUser {
  public readonly email: FormControl<string>;
  public readonly password: FormControl<string>;

  constructor(formBuilder: FormBuilder, data?: SignInUserData) {
    this.email = formBuilder.nonNullable.control(
      data?.email ?? '',
      Validators.required,
    );
    this.password = formBuilder.nonNullable.control(
      data?.password ?? '',
      Validators.required,
    );
  }

  public static toFormGroup(
    formBuilder: FormBuilder,
    data?: SignInUserData,
  ): FormGroup<SignInUser> {
    return formBuilder.group(new SignInUser(formBuilder, data));
  }

  public static fromFormGroup(
    formGroup: FormGroup<SignInUser>,
  ): SignInUserData {
    return formGroup.getRawValue();
  }
}
