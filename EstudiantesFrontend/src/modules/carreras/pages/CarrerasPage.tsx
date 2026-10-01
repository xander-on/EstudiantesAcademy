import { Button } from "@/libs/shadcn/components/ui/button"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/libs/shadcn/components/ui/table";
import { useNavigate } from "react-router";
import { useCarreras } from "../hooks/use-carreras";

export const CarrerasPage = () => {

  const navigation = useNavigate();
  const { getCarrerasQuery, deleteCarreraMutation } = useCarreras();

  const carreras = getCarrerasQuery.data;

  if (getCarrerasQuery.isLoading)
    return <div>Loading...</div>

  if (!carreras)
    return <div>No hay carreras</div>

  return (
    <div className="container mx-auto w-6/12 my-4">
      <div className="flex justify-between">
        <h1>Carreras</h1>
        <Button
          variant="default"
          className="bg-green-500"
          onClick={() => navigation('/carreras/create')}
        >Create</Button>
      </div>


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
            carreras.map(carrera => (
              <TableRow key={carrera.id}>
                <TableCell>{carrera.name}</TableCell>
                <TableCell>{carrera.description}</TableCell>
                <TableCell>
                  <Button
                    variant="default"
                    onClick={() => navigation(`/carreras/update/${carrera.id}`)}
                  >Update</Button>

                  <Button
                    variant="destructive"
                    onClick={() => deleteCarreraMutation.mutate(carrera.id)}
                  >
                    Delete
                  </Button>
                </TableCell>
              </TableRow>
            ))
          }
        </TableBody>
      </Table>
    </div>
  )
}
