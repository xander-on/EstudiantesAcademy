import { estudiantesApi } from "@/config/estudiantesApi";


interface DeleteCarreraResponse {
  id: string;
}

export const deleteCarreraAction = async(id:string) => {
  try{
    const {data} = await estudiantesApi.delete<DeleteCarreraResponse>(`/carreras/${id}`);
    return data;
  }catch(err){
    console.error(err);
    throw err;
  }
}