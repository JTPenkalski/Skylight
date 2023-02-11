import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';

import { SkylightLayoutModule } from './skylight-layout.module';
import { AppComponent } from '../components/app/app.component';

@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    SkylightLayoutModule
  ]
})
export class AppModule { }
