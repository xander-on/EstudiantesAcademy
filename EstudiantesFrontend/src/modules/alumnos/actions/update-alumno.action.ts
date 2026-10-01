import { estudiantesApi } from "@/config/estudiantesApi";


interface UpdateAlumnoRequest {
  id       : string;
  dni      : string;
  name     : string;
  lastName : string;
  email    : string;
}

interface UpdateAlumnoResponse {
  id: string;
}

export const updateAlumnoAction = async (payload:UpdateAlumnoRequest) => {
  try{
    const { data } = await estudiantesApi.patch<UpdateAlumnoResponse>(`/alumnos/${payload.id}`, payload);
    return data;
  }catch(err){
    console.error(err);
    throw err;
  }
}