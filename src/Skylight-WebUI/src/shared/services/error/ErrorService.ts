import { Injectable } from '@angular/core';
import { ValidationErrors } from '@angular/forms';
import { ValidationError } from './error.service';

/**
 * Provides formatted error messages, given the status of a FormControl.
 */

@Injectable({
  providedIn: 'root',
})
export class ErrorService {
  public messages(controlErrors: ValidationErrors): string[] {
    const messages: string[] = [];

    this.append(messages, 'required', controlErrors, () => this.required());
    this.append(messages, 'minLength', controlErrors, (e) => this.minLength(e.requiredLength));
    this.append(messages, 'maxLength', controlErrors, (e) => this.maxLength(e.requiredLength));
    this.append(messages, 'email', controlErrors, () => this.email());

    return messages;
  }

  private append(
    messages: string[],
    errorType: ValidationError,
    controlErrors: ValidationErrors,
    messageFunc: (error: any) => string,
  ): void {
    const error: any = controlErrors[errorType];

    if (error) {
      console.log('Appending ' + errorType);
      messages.push(messageFunc(error));
    }
  }

  private required(): string {
    return 'This field is required.';
  }

  private minLength(length: number): string {
    return `This field must be at least ${length} characters.`;
  }

  private maxLength(length: number): string {
    return `This field must be at most ${length} characters.`;
  }

  private email(): string {
    return 'This field must be a valid email address.';
  }
}
