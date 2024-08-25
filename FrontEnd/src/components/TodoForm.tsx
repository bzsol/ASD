// src/components/TodoForm.tsx
import React, { useState } from 'react';
import { Todo } from '../types/Todo';

interface TodoFormProps {
  onAddTodo: (newTodo: Omit<Todo, 'id'>) => void;
}

const TodoForm: React.FC<TodoFormProps> = ({ onAddTodo }) => {
  const [title, setTitle] = useState<string>('');
  const [description, setDescription] = useState<string>('');
  const [date, setDate] = useState<string>('');
  const [level, setLevel] = useState<number>(1);

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    onAddTodo({
      title,
      description,
      date,
      level,
    });
    setTitle('');
    setDescription('');
    setDate('');
    setLevel(1);
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        placeholder="Title"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        required
      />
      <input
        type="text"
        placeholder="Description"
        value={description}
        onChange={(e) => setDescription(e.target.value)}
      />
      <input
        type="date"
        value={date}
        onChange={(e) => setDate(e.target.value)}
      />
      <input
        type="number"
        placeholder="Level"
        value={level}
        onChange={(e) => setLevel(parseInt(e.target.value))}
        min="1"
      />
      <button type="submit">Add Todo</button>
    </form>
  );
};

export default TodoForm;
