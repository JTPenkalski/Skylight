import { Inject, Injectable } from '@angular/core';
import { StringUtilities } from 'core/utilities';
import { FormControlValidationMessages, FormGuideClient, IFormGuideClient } from 'web/models';
import { VALIDATOR_KEYS } from 'display/input/validators';
import { ControlErrorState } from 'display/types';

/**
 * Formats common error messages to display during form validation.
 **/
@Injectable({
  providedIn: 'root'
})
export class ErrorFormatterService {
  private validationMessages?: FormControlValidationMessages;

  constructor(@Inject(FormGuideClient) private readonly client: IFormGuideClient) { }
  
  /**
   * Formats an error message containing all the validation errors for a control.
   * @param state Information about the current state of a control.
   */
  public formatErrors(state: ControlErrorState): string {
    this.getValidationMessages();

    // Accumulate all errors from each type of validation
    const messages: string[] = [
      ...this.getGeneralValidationMessages(state),
      ...this.getStringValidationMessages(state),
      ...this.getNumericValidationMessages(state),
      ...this.getDateValidationMessages(state)
    ];

    return messages.join('\n');
  }

  /**
   * Retrieves the necessary validation messages, if they aren't cached already.
   */
  private getValidationMessages(): void {
    if (!this.validationMessages) {
      this.client.formGuideGET().subscribe(x => this.validationMessages = x);
    }
  }

  private getGeneralValidationMessages(state: ControlErrorState): string[] {
    const messages: string[] = [];

    if (this.validationMessages) {
      // Required
      if (state.errors[VALIDATOR_KEYS.required]) {
        messages.push(StringUtilities.format(this.validationMessages.errorRequired, state.controlName))
      }

      // Regex Pattern
      if (state.errors[VALIDATOR_KEYS.pattern]) {
        messages.push(StringUtilities.format(this.validationMessages.errorPattern, state.controlName, state.expectedFormat ?? 'any'))
      }
    }

    return messages;
  }

  private getStringValidationMessages(state: ControlErrorState): string[] {
    const messages: string[] = [];

    if (this.validationMessages) {
      // Min Length, Max Length
      messages.push(
        ...this.getMinOrMaxOrRangeMessage(
          state,
          [VALIDATOR_KEYS.minLength, state.validation.stringValidation?.minLength, this.validationMessages.errorMinLength],
          [VALIDATOR_KEYS.maxLength, state.validation.stringValidation?.maxLength, this.validationMessages.errorMaxLength],
          this.validationMessages.errorRangeLength
        )
      );
    }

    return messages;
  }

  private getNumericValidationMessages(state: ControlErrorState): string[] {
    const messages: string[] = [];

    if (this.validationMessages) {
      // Min Value, Max Value
      messages.push(
        ...this.getMinOrMaxOrRangeMessage(
          state,
          [VALIDATOR_KEYS.minValue, state.validation.numericValidation?.minValue, this.validationMessages.errorMinValue],
          [VALIDATOR_KEYS.maxValue, state.validation.numericValidation?.maxValue, this.validationMessages.errorMaxValue],
          this.validationMessages.errorRangeValue
        )
      );
    }

    return messages;
  }

  private getDateValidationMessages(state: ControlErrorState): string[] {
    const messages: string[] = [];

    if (this.validationMessages) {
      // Min Value, Max Value
      messages.push(
        ...this.getMinOrMaxOrRangeMessage(
          state,
          [VALIDATOR_KEYS.minDate, state.validation.dateTimeValidation?.minValue?.toLocaleString(), this.validationMessages.errorMinDate],
          [VALIDATOR_KEYS.maxDate, state.validation.dateTimeValidation?.maxValue?.toLocaleString(), this.validationMessages.errorMaxDate],
          this.validationMessages.errorRangeDate
        )
      );
    }

    return messages;
  }

  /**
   * Adds validators for either the minimum, maximum, or a range of values.
   * @param state Information about the current state of a control.
   * @param min The key to check for validating minimums, the expected minimum from the guide, and its error message.
   * @param max The key to check for validating maximums, the expected maximum from the guide, and its error message.
   * @param rangeMessage The error message to use if both minimum and maximum validators are present.
   * @returns An array of error messages.
   */
  private getMinOrMaxOrRangeMessage(
    state: ControlErrorState,
    min: [key: string, expected: any, message: string],
    max: [key: string, expected: any, message: string],
    rangeMessage: string
  ): string[] {
    const messages: string[] = [];

    if (state.errors[min[0]] && state.errors[max[0]]) {
      // Both validators found, use Range message
      messages.push(StringUtilities.format(rangeMessage, state.controlName, min[1], max[1]))
    } else if (state.errors[min[0]]) {
      // Min validator found, use Min message
      messages.push(StringUtilities.format(min[2], state.controlName, min[1]))
    } else if (state.errors[max[0]]) {
      // Max validator found, use Max message
      messages.push(StringUtilities.format(max[2], state.controlName, max[1]))
    }

    return messages;
  }
}
