import axios from 'axios';
import { Todo } from '../types/Todo.ts';

const API_URL = 'http://localhost:8088/api/Todo';

export const getTodos = () => axios.get<Todo[]>(API_URL);

export const addTodo = (todo: Omit<Todo, 'id'>) => axios.post<Todo>(API_URL, todo);

export const updateTodo = (id: number, todo: Partial<Todo>) => axios.put<Todo>(`${API_URL}/${id}`, todo);

export const deleteTodo = (id: number) => axios.delete(`${API_URL}/${id}`);