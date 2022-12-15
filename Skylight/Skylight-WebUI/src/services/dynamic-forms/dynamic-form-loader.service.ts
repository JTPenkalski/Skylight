import { Injectable } from '@angular/core';

import { Form, FormConfig } from './forms/form';
import { Question } from './questions/question';

@Injectable({
  providedIn: 'root'
})
export class DynamicFormLoaderService {

  constructor() { }

  public loadForm(formTemplate: string): Form {
    const formXML = '<?xml version="1.0" encoding="UTF-8"?> <Form title="Weather Experience"> </Form>';
    const formRaw = require('xml-js').xml2json(formXML, {
      compact: true,
      ignoreDeclaration: true,
      spaces: 4
    });

    console.log(formRaw);

    const formConfig: FormConfig = { ...formRaw.Form._attributes };

    const questions: Question[] = [

    ];

    console.log(formConfig);

    return new Form(formConfig, questions);
  }
}
