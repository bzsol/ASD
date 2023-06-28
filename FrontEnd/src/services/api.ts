import axios from 'axios';
import { Todo } from '../types/Todo.ts';

//const API_URL = process.env.VITE_API_URL;
const API_URL = import.meta.env.VITE_API_URL
console.log(import.meta.env.VITE_API_URL)
if (!API_URL) {
  throw new Error('API_URL is not defined');
}


export const getTodos = () => axios.get<Todo[]>(API_URL);

export const addTodo = (todo: Omit<Todo, 'id'>) => axios.post<Todo>(API_URL, todo);

export const updateTodo = (id: number, todo: Partial<Todo>) => axios.put<Todo>(`${API_URL}/${id}`, todo);

export const deleteTodo = (id: number) => axios.delete(`${API_URL}/${id}`);