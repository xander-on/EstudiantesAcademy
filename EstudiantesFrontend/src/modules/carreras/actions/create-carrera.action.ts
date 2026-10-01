import { estudiantesApi } from "@/config/estudiantesApi";

export interface CreateCarreraRequest {
  code: string;
  name: string;
  description: string;
  materias: string[];
}

interface CreateCarreraResponse {
  id: string
}


export const createCarreraAction = async (payload:CreateCarreraRequest) => {
  try{
    const {data} = await estudiantesApi.post<CreateCarreraResponse>('/carreras', payload);
    return data;
  }catch(err){
    console.error(err);
    throw err;
  }
}