import { Question } from "../questions/question";

export interface FormConfig {
  title: string
}

export class Form implements FormConfig {
  protected _title: string;
  public get title(): string { return this._title; }

  protected _questions: Question[];
  public get questions(): Question[] { return this._questions; }

  constructor(config: FormConfig, questions: Question[]) {
    this._title = config.title;
    this._questions = questions;
  }
}
