import axios from 'axios';
import { Todo } from '../types/Todo.ts';

let API_URL: string | undefined;

// Fetch configuration asynchronously
fetch('/config.json')
  .then(response => response.json())
  .then(data => {
    API_URL = data.API_URL;
    console.log('API_URL set to:', API_URL);
  })
  .catch(error => {
    console.error('Error fetching config:', error);
  });

const getApiUrl = () => {
  if (API_URL) return API_URL;
  return '/api/Todo';
};

export const getTodos = async () => {
  const url = getApiUrl();
  return axios.get<Todo[]>(url);
};

export const addTodo = async (todo: Omit<Todo, 'id'>) => {
  const url = getApiUrl();
  return axios.post<Todo>(url, todo);
};

export const updateTodo = async (id: number, todo: Partial<Todo>) => {
  const url = getApiUrl();
  return axios.put<Todo>(`${url}/${id}`, todo);
};

export const deleteTodo = async (id: number) => {
  const url = getApiUrl();
  return axios.delete(`${url}/${id}`);
};
