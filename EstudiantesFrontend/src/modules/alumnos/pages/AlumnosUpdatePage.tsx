import { Button } from "@/libs/shadcn/components/ui/button"
import { Card, CardContent } from "@/libs/shadcn/components/ui/card"
import { Input } from "@/libs/shadcn/components/ui/input"
import { Label } from "@/libs/shadcn/components/ui/label"
import { useState } from "react"
import { useNavigate, useParams } from "react-router"
import { useAlumnos } from "../hooks/use-alumnos"


const initialForm = {
  id       : '',
  dni      : '',
  name     : '',
  lastName : '',
  email    : ''
}

export const AlumnosUpdatePage = () => {

  const { getAlumnosQuery, updateAlumnoMutation } = useAlumnos();

  const {id} = useParams();
  const alumno = getAlumnosQuery.data?.find(alumno => alumno.id === id);

  const [form, setForm] = useState(alumno || initialForm);
  const navigate = useNavigate();


  const onSubmit = () => {
    updateAlumnoMutation.mutate(form);
    setForm(initialForm);
    navigate('/alumnos');
  }

  return (
    <div className="container mx-auto my-4">
      <Card className='w-xl mx-auto border pb-8'>
        <CardContent>
          <h1 className='text-center text-2xl font-bold mb-4'>Update Alumno</h1>

          <form>

            <div className="grid gap-2">
              <Label>Dni</Label>
              <Input 
                onChange={(e) => setForm({...form, dni: e.target.value})}
                value={form.dni}
                type="text"
                required
              />
            </div>

            <div className="grid gap-2 mt-4">
              <Label>Name</Label>
              <Input 
                onChange={(e) => setForm({...form, name: e.target.value})}
                value={form.name}
                type="text"
                required
              />
            </div>

            <div className="grid gap-2 mt-4">
              <Label>Last Name</Label>
              <Input
                onChange={(e) => setForm({...form, lastName: e.target.value})}
                value={form.lastName} 
                type="text"
                required
              />
            </div>

            <div className="grid gap-2 mt-4">
              <Label>Email</Label>
              <Input
                onChange={(e) => setForm({...form, email: e.target.value})}
                value={form.email} 
                type="text"
                required
              />
            </div>

            <div className='grid grid-cols-1 gap-2 mt-6'>
              <Button
                type='submit'
                className="bg-green-500"
                onClick={ onSubmit}
              >
                Save
              </Button>
            </div>
          </form>

        </CardContent>
      </Card>
    </div>
  )
}
