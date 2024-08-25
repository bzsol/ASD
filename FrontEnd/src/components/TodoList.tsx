// src/components/TodoList.tsx
import React from 'react';
import { Todo } from '../types/Todo';

interface TodoListProps {
  todos: Todo[];
  onUpdateTodo: (id: number, updatedTodo: Partial<Todo>) => void;
  onDeleteTodo: (id: number) => void;
}

const TodoList: React.FC<TodoListProps> = ({ todos, onUpdateTodo, onDeleteTodo }) => {
  return (
    <ul>
      {todos.map((todo) => (
        <li key={todo.id}>
          <span>{todo.title}</span> - <span>{todo.description}</span> - <span>{todo.date}</span>
          <button onClick={() => onUpdateTodo(todo.id, { ...todo, level: todo.level + 1 })}>Increase Level</button>
          <button onClick={() => onDeleteTodo(todo.id)}>Delete</button>
        </li>
      ))}
    </ul>
  );
};

export default TodoList;
