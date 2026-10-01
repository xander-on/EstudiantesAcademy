import { Button } from "@/libs/shadcn/components/ui/button";
import { Card, CardContent } from "@/libs/shadcn/components/ui/card"
import { Checkbox } from "@/libs/shadcn/components/ui/checkbox";
import { Input } from "@/libs/shadcn/components/ui/input"
import { Label } from "@/libs/shadcn/components/ui/label"
import { useMaterias } from "@/modules/materias/hooks/use-materias";
import { CheckboxGroup } from "@base-ui/react";
import { useState } from "react";
import type { CreateCarreraRequest } from "../actions/create-carrera.action";
import { useCarreras } from "../hooks/use-carreras";
import { useNavigate } from "react-router";

const initialForm: CreateCarreraRequest = {
  code: '',
  name: '',
  description: '',
  materias: []
}

export const CarrerasCreatePage = () => {

  const [form, setForm]           = useState(initialForm);
  const { getMateriasQuery }      = useMaterias();
  const { createCarreraMutation } = useCarreras();

  const navigation = useNavigate();

  const onSubmit = () => {
    createCarreraMutation.mutate(form);
    setForm(initialForm);
    navigation('/carreras');
  }

  const materias = getMateriasQuery.data?.map(
    m => ({ value: m.id, label: m.name })
  ) || [];

  return (
    <div className="container mx-auto w-6/12 my-4">
      <Card className='w-xl mx-auto border'>
        <CardContent>
          <h1 className='text-center text-2xl font-bold mb-4'>Create Carrera</h1>

          <form>

            <div className="grid gap-2 mt-4">
              <Label>Code</Label>
              <Input 
                onChange={(e) => setForm({...form, code: e.target.value})}
                value={form.code}
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
              <Label>Description</Label>
              <Input 
                onChange={(e) => setForm({...form, description: e.target.value})}
                value={form.description}
                type="text"
                required
              />
            </div>

            <div className='grid grid-cols-1 gap-2 mt-6'>
              <Label>Materias</Label>

              <div >

                <CheckboxGroup
                  value={form.materias}
                  onValueChange={ materias => setForm({ ...form, materias: materias })}
                  className='overflow-y-scroll border p-2'
                >
                
                  {materias.map((m) => (
                    <div 
                      key={m.value}
                      className="flex items-center space-x-2 mt-1"
                    >
                      <Checkbox value={m.value}/>
                      <Label>{m.label}</Label>
                    </div>
                  ))}
                </CheckboxGroup>
                

              </div>
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
