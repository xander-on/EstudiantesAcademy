import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/libs/shadcn/components/ui/table";
import { useMaterias } from "../hooks/use-materias";
import { Button } from "@/libs/shadcn/components/ui/button";
import { useNavigate } from "react-router";

export const MateriasPage = () => {

  const { getMateriasQuery, deleteMateriaMutation } = useMaterias();
  const navigation = useNavigate();

  const materias = getMateriasQuery.data;

  if(getMateriasQuery.isLoading)
    return <div>Loading...</div>

  if(!materias)
    return <div>No hay materias</div>


  return (
    <div className="container mx-auto w-6/12 my-4">
      <div className="flex justify-between">
        <h1>Materias</h1>
        <Button 
          variant="default" 
          className="bg-green-500"
          onClick={() => navigation('/materias/create')}>Create</Button>
      </div>
      {/* <pre>{JSON.stringify(materias, null, 2)}</pre> */}

       <Table>
        <TableHeader>
          <TableRow>
            <TableHead>Name</TableHead>
            <TableHead>Description</TableHead>
            <TableHead>Actions</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {
            materias.map(materia => (
              <TableRow key={materia.id}>
                <TableCell>{materia.name}</TableCell>
                <TableCell>{materia.description}</TableCell>
                <TableCell>
                  <Button 
                    variant="destructive"
                    onClick={() => deleteMateriaMutation.mutate(materia.id)}
                  >Delete</Button>
                </TableCell>
              </TableRow>
            ))
          }
        </TableBody>
        
      </Table>
    </div>
  )
}
