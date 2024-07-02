/**
 * Converts a "Date" string to a Date.
 * Helpful when Dates from API clients are really strings and need to be converted to proper Dates.
 * @param value The string value of the date.
 * @returns A new Date instance.
 */
export function date(value: Date | undefined): Date | undefined {
  return value ? new Date(value) : undefined;
}
