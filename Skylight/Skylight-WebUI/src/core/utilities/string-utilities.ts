export class StringUtilities {
  /**
   * Replaces ordinal placeholders within a string with the specified values.
   * @param text The string to format.
   * @param values The values to interpolate within the string.
   * @returns The formatted string.
   */
  public static format(text: string, ...values: string[]): string {
    return text.replace(/{(\d+)}/g, (match, index) => { 
      return typeof values[index] != 'undefined'
        ? values[index]
        : match;
    });
  }
}
