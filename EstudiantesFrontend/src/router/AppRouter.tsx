import { createBrowserRouter, RouterProvider } from "react-router";
import { HomePage } from "../modules/shared/pages/HomePage";
import { MateriasPage } from "../modules/materias/pages/MateriasPage";
import { MateriasCreatePage } from "@/modules/materias/pages/MateriasCreatePage";
import { AlumnosPage } from "@/modules/alumnos/pages/AlumnosPage";
import { AlumnosCreatePage } from "@/modules/alumnos/pages/AlumnosCreatePage";
import { AlumnosUpdatePage } from "@/modules/alumnos/pages/AlumnosUpdatePage";
import { CarrerasPage } from "@/modules/carreras/pages/CarrerasPage";
import { CarrerasCreatePage } from "@/modules/carreras/pages/CarrerasCreatePage";


const routes = [
  {
    path:"/",
    element: <HomePage/>
  },
  {
    path:"/materias",
    children:[
      {index:true,    element: <MateriasPage/>},
      {path:"create", element: <MateriasCreatePage/>}
    ] 
  },
  {
    path:"/alumnos",
    children:[
      {index:true,        element: <AlumnosPage/>},
      {path:"create",     element: <AlumnosCreatePage/>},
      {path:"update/:id", element: <AlumnosUpdatePage/>}
    ]
  },
  {
    path:"/carreras",
    children:[
      {index:true,    element: <CarrerasPage/>},
      {path:"create", element: <CarrerasCreatePage/>}
    ]
  }
];


const router = createBrowserRouter(routes);

export const AppRouter = () => 
  <RouterProvider router={router} />
