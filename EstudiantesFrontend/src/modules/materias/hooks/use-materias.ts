import { useMutation, useQuery } from "@tanstack/react-query";
import { getMateriasAction } from "../actions/get-materias.action";
import { createMateriaAction } from "../actions/create-materia.action";
import { deleteMateriaAction } from "../actions/delete-materia.action";

export const useMaterias = () => {
  
  const getMateriasQuery = useQuery({
    queryKey: ['materias'],
    queryFn: () => getMateriasAction(),
    staleTime: 1000 * 60 * 5
  });

  const createMateriaMutation = useMutation({
    mutationFn: createMateriaAction,
    onSuccess: () => getMateriasQuery.refetch()
  });

  const deleteMateriaMutation = useMutation({
    mutationFn: deleteMateriaAction,
    onSuccess: () => getMateriasQuery.refetch()
  });

  return {
    getMateriasQuery,
    createMateriaMutation,
    deleteMateriaMutation
  }
}