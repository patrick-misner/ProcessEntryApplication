import { api } from './AxiosService';
import { ICourtData } from '../models/courts.type';

class CourtsDataService {
  getAll() {
    return api.get<ICourtData[]>(`/api/courts`);
  }

  courtsDataService = new CourtsDataService();
}
