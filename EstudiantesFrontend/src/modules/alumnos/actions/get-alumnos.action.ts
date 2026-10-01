import { estudiantesApi } from "@/config/estudiantesApi";
import type { AlumnoResponse } from "../interfaces/alumno.response";

export const getAlumnosAction = async () => {
  
  try{
    const {data} = await estudiantesApi.get<AlumnoResponse[]>('/alumnos');
    return data;
    
  }catch(e){
    console.error(e);
    throw e;
  }
}