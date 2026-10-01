import { estudiantesApi } from "@/config/estudiantesApi";

interface DeleteAlumnoResponse {
  id: string;
}


export const deleteAlumnoAction = async(id:string) => {
  
  try{
    const { data } = await estudiantesApi.delete<DeleteAlumnoResponse>(`/alumnos/${id}`);
    return data;
  }catch(error){
    console.error(error);
    throw error;
  }
}