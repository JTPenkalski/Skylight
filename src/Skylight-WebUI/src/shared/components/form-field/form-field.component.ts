import { Component, ContentChild, Input } from '@angular/core';
import { NgControl, ValidationErrors } from '@angular/forms';
import { ErrorService } from 'shared/services';

@Component({
  selector: 'skylight-form-field',
  standalone: true,
  imports: [],
  templateUrl: './form-field.component.html',
  styleUrl: './form-field.component.scss',
})
export class FormFieldComponent {
  @ContentChild(NgControl) public control!: NgControl;

  @Input()
  public label?: string;

  constructor(private readonly errorService: ErrorService) {}

  public get name(): string {
    return this.control.name?.toString() ?? '';
  }

  public get invalid(): boolean {
    return !this.control.valid && !!this.control.touched;
  }

  public get errors(): string[] {
    const errors: ValidationErrors | null = this.control.errors;

    return errors ? this.errorService.messages(errors) : [];
  }
}
