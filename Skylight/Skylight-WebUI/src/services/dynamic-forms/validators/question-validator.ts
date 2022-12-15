import { ValidatorFn } from "@angular/forms";

export interface QuestionValidator {
  getValidator(): ValidatorFn;
}
