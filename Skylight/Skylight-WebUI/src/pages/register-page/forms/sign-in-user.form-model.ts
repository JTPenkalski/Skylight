import { FormBuilder, FormControl, Validators } from '@angular/forms';

export class SignInUser {
  public readonly email: FormControl<string>;
  public readonly password: FormControl<string>;

  constructor(formBuilder: FormBuilder) {
    this.email = formBuilder.nonNullable.control('', Validators.required);
    this.password = formBuilder.nonNullable.control('', Validators.required);
  }
}