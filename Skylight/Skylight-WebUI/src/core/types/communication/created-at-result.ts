export type CreateAtResult<T> = {
  actionName: string,
  controllerName: string,
  routeValues: { id: number },
  value?: T
};
