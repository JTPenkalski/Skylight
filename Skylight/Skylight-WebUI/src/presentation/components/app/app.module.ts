import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';

import { SkylightControlsModule } from 'display/input/controls/skylight-controls.module';
import { SkylightFormsModule } from 'display/input/forms/skylight-forms.module';



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
    SkylightFormsModule
  ]
})
export class AppModule { }
