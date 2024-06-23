/**
 * Represents a constructor for a type.
 */
// biome-ignore lint/suspicious/noExplicitAny: Constructors allow any parameter types.
export  type Constructor<T> = new(...args: any[]) => T;
