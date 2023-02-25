export interface IBaseModel {
  id: number;
}

export class BaseModel implements IBaseModel {
  public id: number;

  constructor(id: number = 0) {
    this.id = id;
  }
}
