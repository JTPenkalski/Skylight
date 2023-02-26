/**
 * Base web model for all network communication with the Web API Controllers.
 * It allows the Communication Layer to have an independent, immutable interface consistent with the API that doesn't affect internal presentation logic.
 * This may be refactored to be automatically generated based on the SwaggerDocs in the future.
 **/
export interface IBaseWebModel {
  readonly id: number;
}