import axios from "axios";



export const estudiantesApi = axios.create({
  baseURL: 'http://localhost:5205/api',
})