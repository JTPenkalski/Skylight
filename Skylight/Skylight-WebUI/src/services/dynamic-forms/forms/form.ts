import { Section } from "../sections/section";

/**
 * Contains the customizable properties of a Form model.
 * They are used by the corresponding component when initializing the template.
 **/
export interface FormConfig {
  title: string
}

/**
 * Represents the base Form model to use when creating Dynamic Forms.
 * The properties here are used to generate an equivalent FormGroup in the corresponding component.
 **/
export class Form implements FormConfig {
  protected _title: string;
  public get title(): string { return this._title; }

  protected _sections: Section[]
  public get sections(): Section[] { return this._sections; }

  constructor(config: FormConfig, sections: Section[]) {
    this._title = config.title;
    this._sections = sections;
  }
}
