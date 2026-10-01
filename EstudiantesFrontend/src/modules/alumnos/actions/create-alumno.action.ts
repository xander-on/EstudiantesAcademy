import { estudiantesApi } from "@/config/estudiantesApi";


interface CreateAlumnoRequest {
  dni      : string;
  name     : string;
  lastName : string;
  email    : string;
}
interface CreateAlumnoResponse {
  id: string
}

export const createAlumnoAction = async (payload:CreateAlumnoRequest) => {
  try{
    const {data} = await estudiantesApi.post<CreateAlumnoResponse>('/alumnos', payload);
    return data;
  }catch(err){
    console.error(err);
    throw err;
  }
}