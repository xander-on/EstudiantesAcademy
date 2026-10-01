import { estudiantesApi } from "@/config/estudiantesApi";
import type { MateriaResponse } from "@/modules/materias/interface/materia.response";



export const getCarrerasAction = async() => {
  try{
    const {data} = await estudiantesApi.get<MateriaResponse[]>('/carreras');
    return data;
  }catch(err){
    console.error(err);
    throw err;
  }
}