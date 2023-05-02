import { NgModule } from '@angular/core';
import { RouterModule, TitleStrategy } from '@angular/router';

import { ROUTES_CONFIG } from 'presentation/injection';
import { SkylightTitleStrategy } from './skylight-title-strategy.service';

@NgModule({
  imports: [RouterModule.forRoot(ROUTES_CONFIG)],
  exports: [RouterModule],
  providers: [
    { provide: TitleStrategy, useClass: SkylightTitleStrategy }
  ]
})
export class SkylightRoutingModule { }