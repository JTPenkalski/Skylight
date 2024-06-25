import { Injectable } from '@angular/core';
import { ValidationErrors } from '@angular/forms';

export type ValidationError =
  | 'required'
  | 'minlength'
  | 'maxlength'
  | 'min'
  | 'max'
  | 'email'
  | 'pattern';

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
    this.append(messages, 'minlength', controlErrors, (e) => this.minLength(e.requiredLength));
    this.append(messages, 'maxlength', controlErrors, (e) => this.maxLength(e.requiredLength));
    this.append(messages, 'min', controlErrors, (e) => this.min(e.min));
    this.append(messages, 'max', controlErrors, (e) => this.max(e.max));
    this.append(messages, 'email', controlErrors, () => this.email());
    this.append(messages, 'pattern', controlErrors, (e) => this.pattern(e.requiredPattern));

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

  private min(length: number): string {
    return `This field must have a value of at least ${length}.`;
  }

  private max(length: number): string {
    return `This field must have a value of at most ${length}.`;
  }

  private email(): string {
    return 'This field must be a valid email address.';
  }

  private pattern(pattern: string) {
    return `This field must match the pattern ${pattern}.`;
  }
}
