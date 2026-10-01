import { estudiantesApi } from "@/config/estudiantesApi";

interface DeleteMateriaResponse {
  id: string;
}

export const deleteMateriaAction = async (id:string) => {
  try{
    const {data} = await estudiantesApi.delete<DeleteMateriaResponse>(`/materias/${id}`);
    return data;
  }catch(err){
    console.error(err);
    throw err;
  }
}