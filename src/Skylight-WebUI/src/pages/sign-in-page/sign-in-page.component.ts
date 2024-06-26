import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { NbAlertModule, NbButtonModule, NbCardModule, NbInputModule } from '@nebular/theme';
import { UserService } from 'shared/services';
import { SignInUser, SignInUserData } from './forms';
import { Router } from '@angular/router';

@Component({
  selector: 'skylight-sign-in-page',
  standalone: true,
  imports: [
    NbAlertModule,
    NbCardModule,
    NbButtonModule,
    NbInputModule,
    ReactiveFormsModule
  ],
  templateUrl: './sign-in-page.component.html',
  styleUrl: './sign-in-page.component.scss'
})
export class SignInPageComponent {
  public signInFailed: boolean = false;
  public form: FormGroup<SignInUser> = SignInUser.toFormGroup(this.formBuilder);

  constructor(
    private readonly router: Router,
    private readonly formBuilder: FormBuilder,
    private readonly userService: UserService
  ) { }

  public submitForm(): void {
    if (!this.form.valid) return;

    const registerUser: SignInUserData = SignInUser.fromFormGroup(this.form);

    this.userService.signIn(
      registerUser.email,
      registerUser.password,
    ).subscribe({
      next: result => {
        this.signInFailed = !result

        if (result) {
          this.router.navigate(['/weather-event']);
        }
      },
      error: () => this.signInFailed = true
    });
  }

  public onCloseAlert(): void {
    this.signInFailed = false;
  }
}
