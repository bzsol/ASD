import React, { useState } from 'react';
import { Todo } from '../types/Todo';
import { Button } from 'react-bootstrap';
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';

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
    <Form style={{
      display: 'block',
      width: 700,
      padding: 30,
    }} onSubmit={handleSubmit}>
      <InputGroup className="mb-3">
        <InputGroup.Text id="basic-addon1">Title:</InputGroup.Text>
        <Form.Control
          placeholder="Buy Groceries"
          value={title}
          onChange={(e) => setTitle(e.target.value)} // Update title state
        />
      </InputGroup>
      <InputGroup className="mb-3">
        <InputGroup.Text id="basic-addon1">Description:</InputGroup.Text>
        <Form.Control
          placeholder="2 apples"
          aria-label="Description"
          aria-describedby="basic-addon1"
          value={description}
          onChange={(e) => setDescription(e.target.value)} // Update description state
        />
      </InputGroup>
      <InputGroup className="mb-3">
        <InputGroup.Text id="basic-addon1">Date:</InputGroup.Text>
        <Form.Control
          type="date"
          name="datepic"
          placeholder="DateRange"
          value={date}
          onChange={(e) => setDate(e.target.value)} // Update date state
        />
      </InputGroup>
      <InputGroup className="mb-3">
        <InputGroup.Text id="basic-addon1">Level:</InputGroup.Text>
        <Form.Control
          type="number"
          name="level"
          id="replyNumber" 
          min="0" 
          data-bind="value:replyNumber"
          value={level}
          onChange={(e) => setLevel(Number(e.target.value))} // Update level state
        />
      </InputGroup>
      <Button variant="primary" type="submit">
        Submit
      </Button>
    </Form>
  );
};

export default TodoForm;
