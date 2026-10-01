import { estudiantesApi } from "@/config/estudiantesApi";

interface CreateMateriaResponse {
  id: string;
}

interface CreateMateriaRequest {
  name: string;
  description: string;
}

export const createMateriaAction = async (payload:CreateMateriaRequest) => {
  try{
    const {data} = await estudiantesApi.post<CreateMateriaResponse>('/materias', payload);
    return data;
  }catch(err){
    console.error(err);
    throw err;
  }
}