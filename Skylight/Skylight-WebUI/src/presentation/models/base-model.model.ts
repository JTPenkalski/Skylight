import { IBaseModel as IBaseWebModel } from 'web/web-models';

export interface IBaseModel extends IBaseWebModel {
  // Add any Presentation Layer data fields here...
}

/**
 * Base presentation model for all internal logic within the Skylight Web UI.
 * It allows the Presentation Layer to have an independent interface for presentation logic that doesn't need to be exposed in the API.
 **/
export abstract class BaseModel implements IBaseModel {
  public id?: number;

  constructor(data?: IBaseModel) {
    this.id = this.num(data?.id);
  }

  /**
   * Parses a boolean property from the input data. If no value is provided, the default value is used.
   * @param property The property that either has a value or is undefined.
   * @param defaultValue The default value to use if the property is undefined on the input. It is false by default.
   **/ 
  protected bool(property: boolean | null | undefined, defaultValue: boolean = false): boolean {
    return property ?? defaultValue;
  }

  /**
   * Parses a numeric property from the input data. If no value is provided, the default value is used.
   * @param property The property that either has a value or is undefined.
   * @param defaultValue The default value to use if the property is undefined on the input. It is 0 by default.
   **/ 
  protected num(property: number | null | undefined, defaultValue: number = 0): number {
    return property ?? defaultValue;
  }

  /**
   * Parses a string property from the input data. If no value is provided, the default value is used.
   * @param property The property that either has a value or is undefined.
   * @param defaultValue The default value to use if the property is undefined on the input. It is '' by default.
   **/ 
  protected str(property: string | null | undefined, defaultValue: string = ''): string {
    return property ?? defaultValue;
  }

  /**
   * Parses a Date property from the input data. If no value is provided, the default value is used.
   * @param property The property that either has a value or is undefined.
   * @param defaultValue The default value to use if the property is undefined on the input. It is today by default.
   **/ 
  protected date(property: Date | null | undefined, defaultValue: Date = new Date()): Date {
    return property ?? defaultValue;
  }
  
  /**
   * Parses an array property from the input data. If no value is provided, the default value is used.
   * @param property The property that either has a value or is undefined.
   * @param defaultValue The default value to use if the property is undefined on the input. It is an empty array be default.
   **/ 
  protected arr<T>(property: T[] | null | undefined, defaultValue: T[] = []): T[] {
    return property ?? defaultValue;
  }

  /**
   * Parses an enum property from the input data. If no value is provided, the default value is used.
   * Only supports string enumerations at this time.
   * @param property The property that either has a value or is undefined.
   * @param defaultValue The default value to use if the property is undefined on the input.
   **/ 
  protected enum<T extends string>(property: T | null | undefined, defaultValue: T): T {
    return property ?? defaultValue;
  }
}
