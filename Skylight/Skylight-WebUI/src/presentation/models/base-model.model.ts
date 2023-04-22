import { IBaseModel as IBaseWebModel } from 'web/web-models';

export interface IBaseModel extends IBaseWebModel {
  // Add any Presentation Layer data fields here...
}

export class BaseModel implements IBaseModel {
  public id: number;

  constructor(data?: IBaseModel) {
    this.id = this.num(data?.id);
  }

  /**
   * Parses a boolean property from the input data. If no value is provided, the default value is used.
   * @param property The property that either has a value or is undefined.
   * @param defaultValue The default value to use if the property is undefined on the input. It is false by default.
   **/ 
  protected bool(property: boolean | undefined, defaultValue: boolean = false): boolean {
    return property ?? defaultValue;
  }

  /**
   * Parses a numeric property from the input data. If no value is provided, the default value is used.
   * @param property The property that either has a value or is undefined.
   * @param defaultValue The default value to use if the property is undefined on the input. It is 0 by default.
   **/ 
  protected num(property: number | undefined, defaultValue: number = 0): number {
    return property ?? defaultValue;
  }

  /**
   * Parses a string property from the input data. If no value is provided, the default value is used.
   * @param property The property that either has a value or is undefined.
   * @param defaultValue The default value to use if the property is undefined on the input. It is '' by default.
   **/ 
  protected str(property: string | undefined, defaultValue: string = ''): string {
    return property ?? defaultValue;
  }

  /**
   * Parses a Date property from the input data. If no value is provided, the default value is used.
   * @param property The property that either has a value or is undefined.
   * @param defaultValue The default value to use if the property is undefined on the input. It is today by default.
   **/ 
  protected date(property: Date | undefined, defaultValue: Date = new Date()): Date {
    return property ?? defaultValue;
  }

  /**
   * Parses an object property from the input data. If no value is provided, the default value is used.
   * @param property The property that either has a value or is undefined.
   * @param defaultValue The default value to use if the property is undefined on the input.
   **/ 
  protected obj<T>(property: T | undefined, defaultValue: T): T {
    return property ?? defaultValue;
  }

  /**
   * Parses an array property from the input data. If no value is provided, the default value is used.
   * @param property The property that either has a value or is undefined.
   * @param defaultValue The default value to use if the property is undefined on the input. It is an empty array be default.
   **/ 
  protected arr<T>(property: T[] | undefined, defaultValue: T[] = []): T[] {
    return property ?? defaultValue;
  }
}
