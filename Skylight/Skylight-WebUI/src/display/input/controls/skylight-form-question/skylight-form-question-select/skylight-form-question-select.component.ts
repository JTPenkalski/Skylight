import { Component, Inject, Input, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';

import { FORM_QUESTION_CONFIG, FormQuestionConfiguration } from 'presentation/injection';
import { ErrorFormatterService } from 'display/input/services';
import { SkylightFormQuestionComponent } from '../skylight-form-question.component';
import { SkylightServerOptionsService } from './skylight-server-options.service';
import { ISelectOption } from '../types';

@Component({
  selector: 'skylight-form-question-select[control]',
  templateUrl: './skylight-form-question-select.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-select.component.scss'],
  providers: [SkylightServerOptionsService]
})
export class SkylightFormQuestionSelectComponent extends SkylightFormQuestionComponent implements OnInit {
  @Input() public options?: ISelectOption[];
  @Input() public optionsEndpoint?: string;

  public serverOptions$: Observable<ISelectOption[]> = of([]);

  constructor(
    @Inject(FORM_QUESTION_CONFIG) config: FormQuestionConfiguration,
    errorFormatter: ErrorFormatterService,
    protected readonly serverOptionsService: SkylightServerOptionsService
  ) {
    super(config, errorFormatter);
  }

  public ngOnInit(): void {
    if (this.optionsEndpoint) {
      this.serverOptions$ = this.serverOptionsService.getOptions(this.optionsEndpoint);
    }
  }
}
