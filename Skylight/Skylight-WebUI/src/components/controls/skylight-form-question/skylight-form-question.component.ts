import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, of } from 'rxjs';

import { IFormControlInstance } from 'components/forms/models/form-control-instance.model';
import { ISelectOption } from './models/select-option.model';
import { SkylightServerOptionsService } from './skylight-server-options.service';

type QuestionType = 'date' | 'select' | 'text' | 'textarea';

@Component({
  selector: 'skylight-form-question',
  templateUrl: './skylight-form-question.component.html',
  styleUrls: ['./skylight-form-question.component.scss'],
  providers: [SkylightServerOptionsService]
})
export class SkylightFormQuestionComponent implements OnInit {
  // Required Config
  @Input() public label: string = '';
  @Input() public type: QuestionType = 'text';
  @Input() public control: IFormControlInstance = { name: '', formControl: new FormControl() };
  
  // Dropdown Config
  @Input() public options?: ISelectOption[];
  @Input() public optionsEndpoint?: string;
  public serverOptions$: Observable<ISelectOption[]> = of([]);

  public get required(): boolean { return this.control.formControl.hasValidator(Validators.required); }
  public get formGroup(): FormGroup { return this.control.formControl.parent as FormGroup; }

  constructor(private serverOptionsService: SkylightServerOptionsService) { }

  public ngOnInit(): void {
    // Dropdown Setup
    if (this.optionsEndpoint) {
      this.serverOptions$ = this.serverOptionsService.getOptions(this.optionsEndpoint);
    }
  }
}
