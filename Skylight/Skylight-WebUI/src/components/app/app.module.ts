import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { SkylightControlsModule } from 'components/controls/skylight-controls.module';
import { SkylightFormsModule } from 'components/forms/skylight-forms.module';

@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    SkylightControlsModule,
    SkylightFormsModule
  ]
})
export class AppModule { }
