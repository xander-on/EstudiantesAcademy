import { useMutation, useQuery } from "@tanstack/react-query";
import { getCarrerasAction } from "../actions/get-carreras.action";
import { deleteCarreraAction } from "../actions/delete-carrera.action";
import { createCarreraAction } from "../actions/create-carrera.action";



export const useCarreras = () => {

  const getCarrerasQuery = useQuery({
    queryKey: ['carreras'],
    queryFn: getCarrerasAction,
    staleTime: 1000 * 60 * 5
  });


  const createCarreraMutation = useMutation({
    mutationFn: createCarreraAction,
    onSuccess: () => getCarrerasQuery.refetch()
  });

  const deleteCarreraMutation = useMutation({
    mutationFn: deleteCarreraAction,
    onSuccess: () => getCarrerasQuery.refetch()
  });

  return {
    getCarrerasQuery,
    createCarreraMutation,
    deleteCarreraMutation
  }
}