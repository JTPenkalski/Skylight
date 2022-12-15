import { ValidatorFn, Validators } from "@angular/forms";
import { QuestionValidator } from "./question-validator";

export class RequiredQuestionValidator implements QuestionValidator {
  getValidator(): ValidatorFn { return Validators.required; }
}
