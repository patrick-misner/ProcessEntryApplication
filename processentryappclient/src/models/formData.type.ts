import { IFormField } from './formField.type';

export interface IFormData {
  courts?: IFormField[];
  litigantTypes?: IFormField[];
  documents?: IFormField[];
  instructions?: IFormField[];
  servers?: IFormField[];
  methods?: IFormField[];
  capacities?: IFormField[];
  affidavitTypes?: IFormField[];
}
