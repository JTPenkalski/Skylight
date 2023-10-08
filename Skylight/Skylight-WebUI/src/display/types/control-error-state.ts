import { ValidationErrors } from '@angular/forms'
import { FormControlValidation } from 'web/models'

/**
 * Describes the current state of a control when requesting a formatted error message.
 */
export type ControlErrorState = {
  controlName: string,
  validation: FormControlValidation,
  errors: ValidationErrors,
  expectedFormat?: string
}