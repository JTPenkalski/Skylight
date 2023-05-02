import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

/**
 * Tests if the value if a control is a valid zip code.
 * It must match the RegEx /\d{5}/.
 * @returns True if the control is valid, false otherwise.
 */
export function zipCodeValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const valid = new RegExp('\d{5}').test(control.value); // Very basic Zip Code validator
    return valid ? null : { invalidZipCode: { value: control.value } };
  };
}