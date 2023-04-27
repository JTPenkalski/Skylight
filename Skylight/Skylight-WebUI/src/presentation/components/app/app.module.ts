import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';

import { SkylightControlsModule } from 'display/input/controls/skylight-controls.module';
import { SkylightFormsModule } from 'display/input/forms/skylight-forms.module';
import { SkylightWebClientsModule } from 'web/clients/skylight-web-clients.module';

import { AppComponent } from './app.component';

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
    SkylightWebClientsModule
  ]
})
export class AppModule { }
