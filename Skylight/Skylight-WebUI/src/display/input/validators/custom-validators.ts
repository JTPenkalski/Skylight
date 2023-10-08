import { ValidatorFn } from '@angular/forms';
import { minDate } from './min-date-validator';
import { maxDate } from './max-date-validator';

/**
 * Aggregate for all custom Validators.
 * Import this class to use them in custom forms.
 */
export class CustomValidators {

  /**
   * Tests if the value if a control contains a Date greater than or equal to the specified minimum Date.
   * @param date The minimum Date value.
   * @returns True if the control is valid, false otherwise.
   */
  public static minDate(date: Date): ValidatorFn { return minDate(date); }

  /**
   * Tests if the value if a control contains a Date less than or equal to the specified maximum Date.
   * @param date The maximum Date value.
   * @returns True if the control is valid, false otherwise.
   */
  public static maxDate(date: Date): ValidatorFn { return maxDate(date); }
}