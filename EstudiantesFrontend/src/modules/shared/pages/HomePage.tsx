import { Link } from "react-router";
import { Alert } from "@/libs/shadcn/components/ui/alert";

const menu = [
  {
    name: 'Alumnos',
    path: '/alumnos'
  },
  {
    name: 'Materias',
    path: '/materias'
  },
  {
    name: 'Carreras',
    path: '/carreras'
  }
];


export const HomePage = () => {
  return (
    <div className="container mx-auto my-4 w-xl">
      {
        menu.map(item => (
          <Link to={item.path}>
            <Alert key={item.name} className="my-6 p-4 bg-green-300">
              <h2 className="text-2xl font-bold">{item.name}</h2>
            </Alert>
          </Link>
        ))
      }
    </div>
  )
}
