import { KEY as KEY_MIN_DATE } from './min-date-validator';
import { KEY as KEY_MAX_DATE } from './max-date-validator';

/**
 * Identifies the string keys to use that map to ValidationError results.
 */
export type ValidatorKeys = {
  required: string,
  pattern: string,
  minLength: string,
  maxLength: string,
  minValue: string,
  maxValue: string,
  minDate: string,
  maxDate: string
};

/**
 * The keys to use when inspecting ValidationError messages on FormControls.
 */
export const VALIDATOR_KEYS: ValidatorKeys = {
  required: 'required',
  pattern: 'pattern',
  minLength: 'minLength',
  maxLength: 'maxLength',
  minValue: 'min',
  maxValue: 'max',
  minDate: KEY_MIN_DATE,
  maxDate: KEY_MAX_DATE
};