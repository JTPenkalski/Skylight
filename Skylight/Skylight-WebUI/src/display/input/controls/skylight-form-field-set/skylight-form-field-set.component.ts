import { Component, Input } from '@angular/core';

@Component({
  selector: 'skylight-form-field-set',
  templateUrl: './skylight-form-field-set.component.html',
  styleUrls: ['./skylight-form-field-set.component.scss']
})
export class SkylightFormFieldSetComponent {
  @Input() public label?: string;
}
