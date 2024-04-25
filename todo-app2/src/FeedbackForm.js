import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import './index.css';

function FeedbackForm() {
  const [feedback, setFeedback] = useState({
    rating: '',
    comment: '',
    agree: false
  });

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setFeedback(prevFeedback => ({
      ...prevFeedback,
      [name]: type === 'checkbox' ? checked : value
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(feedback); // Trimiteți feedback-ul către backend sau gestionați-l cum doriți
    // Aici puteți adăuga logica pentru trimiterea feedback-ului către backend
  };

  return (
    <div className="feedback-form-container container">
      <h2>Feedback</h2>
      <Form onSubmit={handleSubmit}>
        <Form.Group controlId="rating">
          <Form.Label>Rating</Form.Label>
          <Form.Control as="select" name="rating" value={feedback.rating} onChange={handleChange} required>
            <option value="">Selectați rating-ul</option>
            <option value="5">5 - Excelent</option>
            <option value="4">4 - Bun</option>
            <option value="3">3 - Satisfăcător</option>
            <option value="2">2 - Slab</option>
            <option value="1">1 - Foarte slab</option>
          </Form.Control>
        </Form.Group>
        <hr />
        <Form.Group controlId="comment">
          <Form.Label>Comentariu</Form.Label>
          <Form.Control as="textarea" rows={4} name="comment" value={feedback.comment} onChange={handleChange} />
        </Form.Group>
        <hr />
        <Form.Group controlId="agree">
          <Form.Check 
            type="checkbox"
            label="Sunt de acord cu termenii și condițiile"
            name="agree"
            checked={feedback.agree}
            onChange={handleChange}
          />
        <hr />
        </Form.Group>
        <Button variant="primary" type="submit">
          Trimite
        </Button>
      </Form>
    </div>
  );
}

export default FeedbackForm;
