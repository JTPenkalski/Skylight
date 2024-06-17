import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { NbButtonModule, NbCardModule, NbInputModule } from '@nebular/theme';
import { UserService } from 'shared/services';
import { RegisterUser, RegisterUserData } from './forms';

@Component({
  selector: 'skylight-register-page',
  standalone: true,
  imports: [
    NbCardModule,
    NbButtonModule,
    NbInputModule,
    ReactiveFormsModule
  ],
  templateUrl: './register-page.component.html',
  styleUrl: './register-page.component.scss'
})
export class RegisterPageComponent {
  public form: FormGroup<RegisterUser> = RegisterUser.toFormGroup(this.formBuilder);

  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly userService: UserService
  ) { }

  public submitForm(): void {
    if (!this.form.valid) return;

    const registerUser: RegisterUserData = RegisterUser.fromFormGroup(this.form);

    this.userService.register(
      registerUser.firstName,
      registerUser.lastName,
      registerUser.email,
      registerUser.password,
    ).subscribe();
  }
}
