import { Injectable } from '@angular/core';
import { KeyValue } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { first, firstValueFrom } from 'rxjs';
import * as XML from 'xml-js';

import { environment } from 'src/environments/environment';
import { Form, FormConfig } from './forms/form';
import { Section, SectionConfig } from './sections/section';
import { Question, QuestionConfig } from './questions/question';
import { DropdownQuestion, DropdownQuestionConfig, DropdownQuestionOptions } from './questions/dropdown-question';
import { TextboxQuestion } from './questions/textbox-question';
import { QuestionValidator } from './validators/question-validator';
import { RequiredQuestionValidator } from './validators/required-question-validator';

/**
 * Reads in an XML string containing the definition for a Dynamic Form.
 * Automatically parses the input and returns a Form model representing the desired Dynamic Form.
 **/
@Injectable({
  providedIn: 'root'
})
export class DynamicFormLoaderService {
  private readonly url: string;

  constructor(
    private http: HttpClient
  ) {
    this.url = environment.apiUrl;
  }

  /**
   * Reads from the supplied XML to generate a Form model.
   * Subscribe to the results of the Observable to generate the Form components.
   * @param formTemplate The XML containing the data necessary to create a Form model.
   **/
  public async loadForm(formTemplate: string): Promise<Form> {
    try {
      const formXML: string | undefined = await firstValueFrom(this.http.get(`${this.url}Forms/${formTemplate}Form`, { responseType: 'text' as const }));
      console.log('XML: ' + formXML);
      if (formXML) {
        return this.parseForm(JSON.parse(XML.xml2json(formXML, {
          compact: true,
          ignoreDeclaration: true,
          spaces: 2
        })).Form as FormSchema)
      }
    } catch (ex) {
      console.error(ex);
    }

    throw `The form '${formTemplate}' was not returned from the server.`;
  }

  /**
   * Parses the JSON data to create a Form model.
   * @param form The JSON object containing the XML data.
   **/
  private parseForm(form: FormSchema): Form {
    if (form._attributes) {
      const formConfig: FormConfig = { ...form._attributes };
      return new Form(formConfig, this.parseSections(form.Section));
    } else {
      throw this.error('The Form node is missing attributes.');
    }
  }

  /**
   * Parses the JSON data to create a Sections array.
   * @param sections The JSON object containing the XML data.
   **/
  private parseSections(sections: SectionSchema | SectionSchema[]): Section[] {
    return Array.isArray(sections)
      ? sections.map(section => this.parseSection(section))
      : [sections].map(section => this.parseSection(section));
  }

  /**
   * Parses the JSON data to create a Section model.
   * @param section The JSON object containing the XML data.
   **/
  private parseSection(section: SectionSchema): Section {
    if (section._attributes) {
      if (section._attributes.id) {
        const sectionConfig: SectionConfig = { ...section._attributes };
        return new Section(sectionConfig, this.parseQuestions(section.Question));
      } else {
        throw this.error('A Section node is missing an ID.');
      }
    } else {
      throw this.error('A Section node is missing its attributes.');
    }
  }

  /**
   * Parses the JSON data to create a Questions array.
   * @param questions The JSON object containing the XML data.
   **/
  private parseQuestions(questions: QuestionSchema | QuestionSchema[]): Question[] {
    return Array.isArray(questions)
      ? questions.map(question => this.parseQuestion(question))
      : [questions].map(question => this.parseQuestion(question))
  }

  /**
   * Parses the JSON data to create a Question model.
   * Will automatically determine which subclass of Question to create and populate the necessary properties accordingly.
   * @param question The JSON object containing the XML data.
   **/
  private parseQuestion(question: QuestionSchema): Question {
    if (question._attributes) {
      if (question._attributes.id) {
        const validators = question.Validators ? this.parseValidators(question.Validators) : undefined;
      
        if (question.Dropdown) { // Dropdown Questions
          const questionConfig: QuestionConfig<string> = { ...question._attributes };

          const options: KeyValue<string, string>[] = [];
          if (question.Dropdown.Option) {
            for (const option of question.Dropdown.Option) {
              options.push({ key: option._text, value: option._attributes ? option._attributes.value : option._text })
            }
          } else if (question.Dropdown._attributes?.server) {
            this.http.get<any[]>(this.url + question.Dropdown._attributes?.server).subscribe({
              next: response => response.forEach(element => {
                if (element.name) {
                  options.push({ key: element.name, value: element.name });
                } else {
                  throw this.error(`Dropdown Question is fetching from a server that returned an object model without a 'name' property. Can't map options.`);
                }
              }),
              error: () => { throw this.error(`Dropdown Question fetching from a server returned an error. Ensure that the API is running.`) }
            });
          } else {
            throw this.error(`Dropdown Question ${question._attributes.id} contains no options. Either specify them manually or use an API.`);
          }

          return new DropdownQuestion(new DropdownQuestionOptions(options), questionConfig, validators);
        } else if (question.Textbox) { // Textbox Questions
          const questionConfig: QuestionConfig<string> = { ...question._attributes };
          return new TextboxQuestion(questionConfig, validators);
        } else { // Invalid Questions
          throw this.error(`Question ${question._attributes.id} contains an unsupported control type.`);
        }
      } else {
        throw this.error('A Question node is missing an ID.');
      }
    } else {
      throw this.error('A Question node is missing its attributes.');
    }
  }

  /**
   * Parses the JSON data to create a QuestionValidator array.
   * @param validators The JSON object containing the XML data.
   **/
  private parseValidators(validators: ValidatorSchema): QuestionValidator[] {
    const questionValidators: QuestionValidator[] = [];

    if (validators.RequiredValidator) {
      questionValidators.push(new RequiredQuestionValidator());
    }

    return questionValidators;
  }

  /**
   * Returns a string to use when throwing a parsing error.
   * @param reason The explanation for why parsing failed.
   **/
  private error(reason: string): string {
    return `[Dynamic Forms] - ${reason} Ensure that the XML file adheres to the schema.`;
  }
}

interface XMLSchema<T> {
  _attributes?: T;
}

interface FormSchema extends XMLSchema<FormConfig> {
  Section: SectionSchema | SectionSchema[];
}

interface SectionSchema extends XMLSchema<SectionConfig> {
  Question: QuestionSchema | QuestionSchema[];
}

interface QuestionSchema extends XMLSchema<QuestionConfig<any>> {
  Dropdown?: DropdownSchema;
  Textbox?: TextboxSchema;
  Validators?: ValidatorSchema;
}

interface ControlSchema<T> extends XMLSchema<T> {
  // Potentially any attributes/properties shared between all control types
}

interface DropdownSchema extends ControlSchema<DropdownQuestionConfig<any>> {
  Option?: DropdownQuestionOptionSchema[];
}

interface DropdownQuestionOptionSchema extends XMLSchema<{ value: string }> {
  _text: string;
}

interface TextboxSchema extends ControlSchema<{}> {
  
}

interface ValidatorSchema extends XMLSchema<{}> {
  RequiredValidator?: {};
}
