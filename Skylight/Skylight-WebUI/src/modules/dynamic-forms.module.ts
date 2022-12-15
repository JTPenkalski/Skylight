import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DynamicFormLoaderService } from '../services/dynamic-forms/dynamic-form-loader.service';

@NgModule({
  imports: [
    CommonModule
  ],
  providers: [
    DynamicFormLoaderService
  ]
})
export class DynamicFormsModule { }
