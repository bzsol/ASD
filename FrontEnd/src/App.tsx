// src/App.tsx
import React, { useEffect, useState } from 'react';
import { Todo } from './types/Todo';
import { getTodos, addTodo, updateTodo, deleteTodo } from './services/api';
import TodoList from './components/TodoList.tsx';
import TodoForm from './components/TodoForm.tsx';


const App: React.FC = () => {
  const [todos, setTodos] = useState<Todo[]>([]);

  useEffect(() => {
    fetchTodos();
  }, []);

  const fetchTodos = async () => {
    try {
      const response = await getTodos();
      setTodos(response.data);
    } catch (error) {
      console.error('Error fetching todos:', error);
    }
  };

  const handleAddTodo = async (newTodo: Omit<Todo, 'id'>) => {
    try {
      await addTodo(newTodo);
      fetchTodos();
    } catch (error) {
      console.error('Error adding todo:', error);
    }
  };

  const handleUpdateTodo = async (id: number, updatedTodo: Partial<Todo>) => {
    try {
      await updateTodo(id, updatedTodo);
      fetchTodos();
    } catch (error) {
      console.error('Error updating todo:', error);
    }
  };

  const handleDeleteTodo = async (id: number) => {
    try {
      await deleteTodo(id);
      fetchTodos();
    } catch (error) {
      console.error('Error deleting todo:', error);
    }
  };

  return (
    <div>
      <h1>Todo List</h1>
      <TodoForm onAddTodo={handleAddTodo} />
      <TodoList todos={todos} onUpdateTodo={handleUpdateTodo} onDeleteTodo={handleDeleteTodo} />
    </div>
  );
};

export default App;

