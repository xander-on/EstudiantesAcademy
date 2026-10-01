import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/libs/shadcn/components/ui/table";
import { Button } from "@/libs/shadcn/components/ui/button";
import { useNavigate } from "react-router";
import { useAlumnos } from "../hooks/use-alumnos";

export const AlumnosPage = () => {

  const { getAlumnosQuery, deleteAlumnoMutation } = useAlumnos();
  const navigation = useNavigate();

  const alumnos = getAlumnosQuery.data;

  if(getAlumnosQuery.isLoading)
    return <div>Loading...</div>

  if(!alumnos)
    return <div>No hay alumnos</div>


  return (
    <div className="container mx-auto w-6/12 my-4">
      <div className="flex justify-between">
        <h1 className="text-2xl font-bold">Alumnos</h1>
        <Button 
          variant="default" 
          className="bg-green-500"
          onClick={() => navigation('/alumnos/create')}>Create</Button>
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
            alumnos.map(alumno => (
              <TableRow key={alumno.id}>
                <TableCell>{alumno.name}</TableCell>
                <TableCell>{alumno.lastName}</TableCell>
                <TableCell>

                  <Button 
                    variant="secondary"
                    onClick={() => navigation(`/alumnos/update/${alumno.id}`)}
                  >Update</Button>

                  <Button 
                    variant="destructive"
                    onClick={() => deleteAlumnoMutation.mutate(alumno.id)}
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
