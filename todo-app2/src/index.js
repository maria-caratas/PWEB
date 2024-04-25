// App.js
import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import FeedbackForm from './FeedbackForm';
import AdminPage from './App';
import ReactDOM from 'react-dom/client';
import { Navbar, Nav, Container } from 'react-bootstrap';
import LoginForm from './LoginForm';

function NavigationBar() {
  return (
    <Navbar bg="dark" variant="dark" expand="md">
      <Container>
          <Nav className="me-auto">
            <Nav.Link href="/">Login</Nav.Link>
            <Nav.Link href="/feedback">Feedback</Nav.Link>
            <Nav.Link href="/admin">Administrare</Nav.Link>
          </Nav>
      </Container>
    </Navbar>
  );
}

function AppIndex() {
  return (
    <Router>
      <div>
        <NavigationBar />

        <Routes>
          <Route path="/feedback" element={<FeedbackForm />} />
          <Route path="/admin" element={<AdminPage />} />
          {/* Adaugă o rută pentru pagina de start */}
          <Route path="/" element={<LoginForm />} />
        </Routes>
      </div>
    </Router>
  );
}

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <AppIndex />
  </React.StrictMode>
);
