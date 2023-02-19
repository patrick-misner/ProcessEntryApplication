import { api } from '../services/AxiosService';
import { IProcessData } from "../models/process.type"

class ProcessDataService {
  get(id: string) {
    return api.get<IProcessData>(`/processentries/${id}`);
  }

  create(data: IProcessData) {
    return api.post<IProcessData>("/processentries", data);
  }

  update(data: IProcessData, id: any) {
    return api.put<any>(`/processentries/${id}`, data);
  }

  delete(id: any) {
    return api.delete<any>(`/processentries/${id}`);
  }

  deleteAll() {
    return api.delete<any>(`/processentries`);
  }

  findByTitle(title: string) {
    return api.get<Array<IProcessData>>(`/processentries?title=${title}`);
  }
}

export const processDataService = new ProcessDataService();