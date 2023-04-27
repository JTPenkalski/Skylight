/**
 * Allows the client to "hide" properties, similar to that in C# and replace them with a different type.
 * This is useful when mapping web models to presentation models,
 * when a presentation model contains a property that must be mapped itself from a web model to a presentation model.
 **/
export type Modify<T, R> = Omit<T, keyof R> & R;