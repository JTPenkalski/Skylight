import { Injectable } from '@angular/core';
import { KeyValue } from '@angular/common';
import * as XML from 'xml-js';

import { Form, FormConfig } from './forms/form';
import { Section, SectionConfig } from './sections/section';
import { Question, QuestionConfig } from './questions/question';
import { DropdownQuestion, DropdownQuestionOptions } from './questions/dropdown-question';
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
  /**
   * Reads from the supplied XML to generate a Form model.
   * @param formTemplate The XML containing the data necessary to create a Form model.
   **/
  public loadForm(formTemplate: string): Form {
    const formXML = '<?xml version="1.0" encoding="UTF-8"?> <Form title="Weather Experience"> <Section id="area1" title="Area 1"> <Question id="name" label="Name"> <Dropdown> <Option value="hello">Hello</Option> <Option>World</Option> </Dropdown> <Validators> <RequiredValidator/> </Validators> </Question> <Question id="cookie" label="Cookie"> <Textbox/> </Question> </Section> <Section id="section2" title="Section 2"> <Question id="weather" label="Weather"> <Textbox/> </Question> </Section> </Form>';
    const formRaw = XML.xml2json(formXML, {
      compact: true,
      ignoreDeclaration: true,
      spaces: 2
    });

    return this.parseForm(JSON.parse(formRaw).Form as FormSchema);
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
          for (const option of question.Dropdown.Option) {
            options.push({ key: option._text, value: option._attributes ? option._attributes.value : option._text })
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

interface DropdownSchema extends ControlSchema<{}> {
  Option: DropdownQuestionOptionSchema[];
}

interface DropdownQuestionOptionSchema extends XMLSchema<{ value: string }> {
  _text: string;
}

interface TextboxSchema extends ControlSchema<{}> {
  
}

interface ValidatorSchema extends XMLSchema<{}> {
  RequiredValidator?: {};
}
