import { Component } from '@angular/core';
import { NonNullableFormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import {  } from '@angular/material';

@Component({
  selector: 'form-location',
  templateUrl: './form-location.component.html'
})
export class FormLocationComponent {
  location = this.formBuilder.group({
    city: ['', Validators.required],
    zipCode: ['', Validators.required],
    country: ['', Validators.required]
  });

  constructor(private formBuilder: NonNullableFormBuilder) { }

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.warn(this.location.value);
  }
}
