import { estudiantesApi } from "../../../config/estudiantesApi";
import type { MateriaResponse } from "../interface/materia.response";


export const getMateriasAction = async () => {
  
  try{
    const {data} = await estudiantesApi.get<MateriaResponse[]>('/materias');
    return data;
    
  }catch(e){
    console.error(e);
    throw e;
  }
}