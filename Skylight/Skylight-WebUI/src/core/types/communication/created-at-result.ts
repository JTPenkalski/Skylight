export type CreatedAtResult<T> = {
  actionName: string,
  controllerName: string,
  routeValues: { id: number },
  value?: T
};
