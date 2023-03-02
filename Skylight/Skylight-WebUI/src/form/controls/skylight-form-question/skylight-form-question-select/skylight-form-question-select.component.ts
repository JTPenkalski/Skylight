import { Component, Inject, Input, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';

import { ISelectOption } from '../models/select-option.model';
import { SkylightFormQuestionComponent } from '../skylight-form-question.component';
import { FormQuestionConfiguration, FORM_QUESTION_CONFIG_TOKEN } from '../form-question-configuration.service';
import { SkylightServerOptionsService } from './skylight-server-options.service';

@Component({
  selector: 'skylight-form-question-select[instance]',
  templateUrl: './skylight-form-question-select.component.html',
  styleUrls: ['../skylight-form-question.component.scss', './skylight-form-question-select.component.scss'],
  providers: [SkylightServerOptionsService]
})
export class SkylightFormQuestionSelectComponent extends SkylightFormQuestionComponent implements OnInit {
  @Input() public options?: ISelectOption[];
  @Input() public optionsEndpoint?: string;

  public serverOptions$: Observable<ISelectOption[]> = of([]);

  constructor(
    @Inject(FORM_QUESTION_CONFIG_TOKEN) config: FormQuestionConfiguration,
    protected readonly serverOptionsService: SkylightServerOptionsService
  ) {
    super(config);
  }

  public ngOnInit(): void {
    if (this.optionsEndpoint) {
      this.serverOptions$ = this.serverOptionsService.getOptions(this.optionsEndpoint);
    }
  }
}
