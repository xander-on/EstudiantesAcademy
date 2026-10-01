import { Button } from '@/libs/shadcn/components/ui/button';
import { Card, CardContent } from '@shadcn/components/ui/card';
import { Input } from '@shadcn/components/ui/input';
import { Label } from '@shadcn/components/ui/label';
import { useState } from 'react';
import { useMaterias } from '../hooks/use-materias';
import { useNavigate } from 'react-router';


const initialForm = {
  name: '',
  description: ''
}

export const MateriasCreatePage = () => {

  const navigate = useNavigate();
  const [form, setForm] = useState(initialForm);
  const { createMateriaMutation } = useMaterias();

  const onSubmit = () => {
    createMateriaMutation.mutate(form);
    setForm(initialForm);
    navigate('/materias');
  }

  return (
    <div className="container mx-auto w-6/12 my-4">

      <Card className='border'>
        <CardContent>
          <h1 className='text-center text-2xl font-bold mb-4'>Create Materia</h1>

          <form>
            <div className="grid gap-2">
              <Label htmlFor="name">Name</Label>
              <Input 
                onChange={(e) => setForm({...form, name: e.target.value})}
                value={form.name}
                type="text"  
              />
            </div>

            <div className="grid gap-2 mt-4">
              <Label htmlFor="name">Description</Label>
              <Input
                onChange={(e) => setForm({...form, description: e.target.value})}
                value={form.description} 
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
