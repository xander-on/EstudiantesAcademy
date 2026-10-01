import { useMutation, useQuery } from "@tanstack/react-query"
import { getAlumnosAction } from "../actions/get-alumnos.action";
import { deleteAlumnoAction } from "../actions/delete-alumno.action";
import { createAlumnoAction } from "../actions/create-alumno.action";
import { updateAlumnoAction } from "../actions/update-alumno.action";


export const useAlumnos = () => {
  
  const getAlumnosQuery = useQuery({
    queryKey: ['alumnos'],
    queryFn: getAlumnosAction,
    staleTime: 1000 * 60 * 5
  });

  const createAlumnoMutation = useMutation({
    mutationFn: createAlumnoAction,
    onSuccess: () => getAlumnosQuery.refetch()
  });

  const updateAlumnoMutation = useMutation({
    mutationFn: updateAlumnoAction,
    onSuccess: () => getAlumnosQuery.refetch()
  });

  const deleteAlumnoMutation = useMutation({
    mutationFn: deleteAlumnoAction,
    onSuccess: () => getAlumnosQuery.refetch()
  });

  return {
    getAlumnosQuery,
    createAlumnoMutation,
    updateAlumnoMutation,
    deleteAlumnoMutation
  }
}