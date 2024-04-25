import React, { useState } from 'react';
import ReactDOM from 'react-dom';
import LoginForm from './LoginForm';

function LogoutButton() {
  const handleLogout = () => {
    ReactDOM.createRoot(<LoginForm />, document.getElementById('root'));
  };

  return (
    <button onClick={handleLogout}>Logout</button>
  );
}

export default LogoutButton;