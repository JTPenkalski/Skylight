import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

export type RegisterUserData = {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
};

export class RegisterUser {
  public readonly firstName: FormControl<string>;
  public readonly lastName: FormControl<string>;
  public readonly email: FormControl<string>;
  public readonly password: FormControl<string>;

  constructor(formBuilder: FormBuilder, data?: RegisterUserData) {
    this.firstName = formBuilder.nonNullable.control(data?.firstName ?? '', [Validators.required]);
    this.lastName = formBuilder.nonNullable.control(data?.lastName ?? '', [Validators.required]);
    this.email = formBuilder.nonNullable.control(data?.email ?? '', [
      Validators.required,
      Validators.email,
    ]);
    this.password = formBuilder.nonNullable.control(data?.password ?? '', [
      Validators.required,
      Validators.minLength(8),
    ]);
  }

  public static toFormGroup(
    formBuilder: FormBuilder,
    data?: RegisterUserData,
  ): FormGroup<RegisterUser> {
    return formBuilder.group(new RegisterUser(formBuilder, data));
  }

  public static fromFormGroup(formGroup: FormGroup<RegisterUser>): RegisterUserData {
    return formGroup.getRawValue();
  }
}
