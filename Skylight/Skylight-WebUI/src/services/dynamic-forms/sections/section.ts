import { Question } from "../questions/question";

/**
 * Contains the customizable properties of a Section model.
 * They are used by the corresponding component when initializing the template.
 **/
export interface SectionConfig {
  key: string,
  title: string
}

/**
 * Represents a Section model to use when creating Dynamic Forms.
 * The properties here are used to generate an equivalent FormGroup in the corresponding component.
 * Sections utilize the <section> tag to delineate important groups of controls within a form.
 **/
export class Section implements SectionConfig {
  protected _key: string;
  public get key(): string { return this._key; }

  protected _title: string;
  public get title(): string { return this._title; }

  protected _questions: Question[];
  public get questions(): Question[] { return this._questions; }

  constructor(config: SectionConfig, questions: Question[]) {
    this._key = config.key;
    this._title = config.title;
    this._questions = questions;
  }
}
