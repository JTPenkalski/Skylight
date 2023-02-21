export interface IBaseModel {
  id: number;
}

export class BaseModel implements IBaseModel {
  public id: number;

  constructor(id: number) {
    this.id = id;
  }
}
