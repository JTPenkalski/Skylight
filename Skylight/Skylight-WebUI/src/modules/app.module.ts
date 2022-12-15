import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';

import { SkylightControlsModule } from './skylight-controls.module';
import { AppComponent } from '../components/app/app.component';
import { DynamicFormsModule } from './dynamic-forms.module';

@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    DynamicFormsModule,
    SkylightControlsModule
  ]
})
export class AppModule { }
