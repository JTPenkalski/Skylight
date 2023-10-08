import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export const KEY: string = 'maximumDate';

export function maxDate(date: Date): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const valid: boolean = !control.value || new Date(control.value) <= date;
    return valid ? null : { [KEY]: { value: control.value } };
  };
}