import { Type } from "@angular/core";

import { DynamicFormQuestionComponent } from "src/components/controls/dynamic-forms/dynamic-form-question/dynamic-form-question.component";
import { QuestionValidator } from "../validators/question-validator";

/**
 * Contains the customizable properties of a Question model.
 * They are used by the corresponding component when initializing the template.
 **/
export interface QuestionConfig<T> {
  id: string,
  value: T | undefined,
  label: string,
  enabled: boolean | undefined,
}

/**
 * Represents the base Question model to use when creating Dynamic Forms.
 * The properties here are used to generate an equivalent FormControl in the corresponding component.
 * This class must be overridden to support various question types and to supply control-specific data.
 **/
export abstract class Question<T = any> implements QuestionConfig<T> {
  protected _id: string;
  public get id(): string { return this._id; }

  protected _value: T | undefined;
  public get value(): T | undefined { return this._value; }

  protected _label: string;
  public get label(): string { return this._label; }

  protected _enabled: boolean;
  public get enabled(): boolean { return this._enabled; }

  protected _validators: QuestionValidator[];
  public get validators(): QuestionValidator[] { return this._validators; }

  /**
   * The corresponding component to use when initializing this Question in a template.
   **/
  public abstract get dynamicComponent(): Type<DynamicFormQuestionComponent>;

  constructor(config: QuestionConfig<T>, validators?: QuestionValidator[]) {
    this._id = config.id;
    this._value = config.value;
    this._label = config.label;
    this._enabled = !config.enabled;
    this._validators = validators || [];
  }
}
