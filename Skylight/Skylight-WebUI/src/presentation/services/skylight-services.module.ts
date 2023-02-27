import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { REQUESTOR_PROVIDERS } from 'presentation/injection';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [
    ...REQUESTOR_PROVIDERS
  ]
})
export class SkylightServicesModule { }
