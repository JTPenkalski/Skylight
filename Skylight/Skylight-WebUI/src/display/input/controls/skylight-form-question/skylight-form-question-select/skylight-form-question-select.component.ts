import { Component, Inject, Input } from '@angular/core';
import { Observable, of } from 'rxjs';

import { FORM_QUESTION_CONFIG_TOKEN, FormQuestionConfiguration } from 'presentation/injection';
import { ErrorFormatterService } from 'display/input/services';
import { SkylightFormQuestionComponent } from '../skylight-form-question.component';
import { SkylightServerOptionsService } from './skylight-server-options.service';
import { ISelectOption } from '../types';
import { FormControlGuide } from 'web/models';

@Component({
  selector: 'skylight-form-question-select[control]',
  templateUrl: './skylight-form-question-select.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-select.component.scss'],
  providers: [{ provide: SkylightFormQuestionComponent, useExisting: SkylightFormQuestionSelectComponent }, SkylightServerOptionsService]
})
export class SkylightFormQuestionSelectComponent extends SkylightFormQuestionComponent {
  @Input() public options?: ISelectOption[];
  @Input() public optionsEndpoint?: string;
  @Input() public multiple : boolean = false;

  public serverOptions$: Observable<ISelectOption[]> = of([]);

  constructor(
    @Inject(FORM_QUESTION_CONFIG_TOKEN) config: FormQuestionConfiguration,
    errorFormatter: ErrorFormatterService,
    protected readonly serverOptionsService: SkylightServerOptionsService
  ) {
    super(config, errorFormatter);
  }

  public override ngOnInit(): void {
    super.ngOnInit();

    if (this.optionsEndpoint) {
      this.serverOptions$ = this.serverOptionsService.getOptions(this.optionsEndpoint);
    }
  }

  protected override implementGuide(guide?: FormControlGuide): void {
    super.implementGuide(guide);

    if (guide?.readOnly) {
      this.control.disable();
    }
  }

  /**
   * Determines if 2 options' values should be considered equal.
   * @param first The first value.
   * @param second The second value.
   * @returns True if the values match, false otherwise.
   */
  protected compareValues(first: any, second: any): boolean {
    return first && second && first.id === second.id;
  }
}
