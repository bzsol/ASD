// src/components/TodoList.tsx
import React from 'react';
import { Todo } from '../types/Todo';
import { Button, Table } from 'react-bootstrap';

interface TodoListProps {
  todos: Todo[];
  onUpdateTodo: (id: number, updatedTodo: Partial<Todo>) => void;
  onDeleteTodo: (id: number) => void;
}

const TodoList: React.FC<TodoListProps> = ({ todos, onDeleteTodo }) => {
  return (
    <Table striped bordered hover>
      <thead>
        <tr>
          <th>Title</th>
          <th>Description</th>
          <th>Date</th>
          <th>Level</th>
        </tr>
      </thead>
      <tbody>
      {todos.map((todo) => (
        <tr key={todo.id}>
          <td>{todo.title}</td>
          <td>{todo.description}</td>
          <td>{todo.date}</td>
          <td>{todo.level}</td>
          <td><Button variant='danger' onClick={() => onDeleteTodo(todo.id)}>Delete</Button></td>
        </tr>
      ))}
      </tbody>
    </Table>
  );
};

export default TodoList;
