import { Directive, Inject, Input } from '@angular/core';
import { AbstractControl, FormArray, FormControl, FormGroup, Validators } from '@angular/forms';

import { FORM_QUESTION_CONFIG, FormQuestionConfiguration } from 'presentation/injection';
import { IAbstractControlInstance } from './models';

/**
 * Base component for all Form Question components.
 * @requires [instance]: The name and AbstractControl associated with this control.
 **/
@Directive()
export abstract class SkylightFormQuestionComponent {
  @Input() public label: string = '';
  @Input() public instance: IAbstractControlInstance = { name: '', control: new FormControl() };

  public get name(): string | number { return this.instance.name; }
  public get control(): AbstractControl { return this.instance.control; }
  public get parent(): FormGroup { return this.control.parent as FormGroup; }

  public get required(): boolean { return this.control.hasValidator(Validators.required); }

  constructor(
    @Inject(FORM_QUESTION_CONFIG) public readonly config: FormQuestionConfiguration,
  ) { }

  /**
   * Formats a specified validation message with this control's specific label.
   * @param message The message from the FormQuestionConfiguration's validation property.
   * @returns A formatted string to display for a validation error message.
   **/
  public formatError(message: string): string {
    return message.replace('{name}', this.label);
  }

  /**
   * Maps an AbstractControl to an AbstractControlInstance.
   * @param name The name or index of the AbstractControl within a control.
   * @param parent Optionally provide a more specific parent to search under.
   * @returns An object with the AbstractControl and its name within the FormGroup.
   **/
  public getControlInstance(name: string | number, parent?: FormGroup | FormArray): IAbstractControlInstance {
    name = name.toString(); // Convert string | number to string
    const control: AbstractControl | null = parent?.get(name) ?? this.parent.get(name);

    if (!control) {
      throw new Error(`Cannot create IAbstractControlInstance. The control "${name}" is not an AbstractControl.`);
    }

    return {
      name: name,
      control: control
    };
  }
}
