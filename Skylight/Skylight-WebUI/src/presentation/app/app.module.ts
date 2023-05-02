import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';

import { SkylightControlsModule } from 'display/input/controls/skylight-controls.module';
import { SkylightFormsModule } from 'display/input/forms/skylight-forms.module';
import { SkylightRoutingModule } from 'presentation/routing/skylight-routing.module';
import { SkylightWebClientsModule } from 'web/clients/skylight-web-clients.module';

import { AppComponent } from './app.component';

import { ROUTE_NAMES_CONFIG_PROVIDER, ROUTES_CONFIG_PROVIDER } from 'presentation/injection';

@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    SkylightControlsModule,
    SkylightFormsModule,
    SkylightRoutingModule,
    SkylightWebClientsModule
  ],
  providers: [
    ...ROUTE_NAMES_CONFIG_PROVIDER,
    ...ROUTES_CONFIG_PROVIDER
  ]
})
export class AppModule { }
