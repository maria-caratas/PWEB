import React, { useState } from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './LoginForm.css'; // Presupunând că ai creat un fișier de stiluri

function LoginForm() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      // Logica de verificare a credențialelor
      const response = await fetch('/api/login?utilizator='+username+'&parola='+password, {
        method: 'POST'      
      });

      const content = await response.text();
      
      if (content !== "logat") {
        throw new Error('Autentificare nereușita');
      }

      // Autentificare reușita, redirectionare către App
      onLogin();
    } catch (error) {
      setError("Autentificare nereusita!");
    }
  };

  const onLogin = () => {
    ReactDOM.render(<App />, document.getElementById('root'));
  };

  return (
    <div className="login-container">
      <h2>Logare</h2>
      {error && <div className="error">{error}</div>}
      <form onSubmit={handleSubmit} className="login-form">
        <div className="form-group">
          <label htmlFor="username">Utilizator:</label>
          <input type="text" id="username" value={username} onChange={(e) => setUsername(e.target.value)} required />
        </div>
        <div className="form-group">
          <label htmlFor="password">Parola:</label>
          <input type="password" id="password" value={password} onChange={(e) => setPassword(e.target.value)} required />
        </div>
        <button type="submit" className="login-button">Autentificare</button>
      </form>
    </div>
  );
}

export default LoginForm;
