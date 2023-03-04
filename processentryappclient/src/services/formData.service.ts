import { api } from './AxiosService';
import { IFormData } from '../models/formData.type';

class FormDataService {
  getAll() {
    return api.get<IFormData[]>(`/api/processentryformdata/`);
  }

  formDataService = new FormDataService();
}
