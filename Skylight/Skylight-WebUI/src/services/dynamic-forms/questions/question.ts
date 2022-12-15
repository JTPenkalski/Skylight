import { Type } from "@angular/core";

import { DynamicFormQuestionComponent } from "../../../components/controls/dynamic-forms/dynamic-form-question/dynamic-form-question.component";
import { QuestionValidator } from "../validators/question-validator";

export interface QuestionConfig<T> {
  key: string,
  value: T | undefined,
  label: string,
  enabled: boolean,
}

export abstract class Question<T = any> implements QuestionConfig<T> {
  protected _key: string;
  public get key(): string { return this._key; }

  protected _value: T | undefined;
  public get value(): T | undefined { return this._value; }

  protected _label: string;
  public get label(): string { return this._label; }

  protected _enabled: boolean;
  public get enabled(): boolean { return this._enabled; }

  protected _validators: QuestionValidator[];
  public get validators(): QuestionValidator[] { return this._validators; }

  public abstract get dynamicComponent(): Type<DynamicFormQuestionComponent>;

  constructor(config: QuestionConfig<T>, validators?: QuestionValidator[]) {
    this._key = config.key;
    this._value = config.value;
    this._label = config.label;
    this._enabled = config.enabled;
    this._validators = validators || [];
  }
}
