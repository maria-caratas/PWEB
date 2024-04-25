import React, { useState } from 'react';
import './index.css'; // Importam stilurile CSS
import CapitoleList from './CapitoleList';
import CapitolForm from './CapitolForm';
import IntrebariList from './IntrebariList';
import IntrebariForm from './IntrebariForm';
import RezultatQuizzList from './RezultatQuizzList';
import RezultatQuizzForm from './RezultatQuizzForm';
import UtilizatorList from './UtilizatorList';
import UtilizatorForm from './UtilizatorForm';
import LogoutButton from './LogoutButton';

function App() {
  const [editMode, setEditMode] = useState(false);
  const [selectedCapitol, setSelectedCapitol] = useState(null);
  const [selectedIntrebare, setSelectedIntrebare] = useState(null);
  const [selectedRezultatQuizz, setSelectedRezultatQuizz] = useState(null);
  const [selectedUtilizator, setSelectedUtilizator] = useState(null);

  const handleEditCapitol = (capitol) => {
    setSelectedCapitol(capitol);
    setSelectedIntrebare(null);
    setSelectedRezultatQuizz(null);
    setSelectedUtilizator(null);
    setEditMode(true);
  };

  const handleEditIntrebare = (intrebare) => {
    setSelectedIntrebare(intrebare);
    setSelectedCapitol(null);
    setSelectedRezultatQuizz(null);
    setSelectedUtilizator(null);
    setEditMode(true);
  };

  const handleEditRezultatQuizz = (rezultatQuizz) => {
    setSelectedRezultatQuizz(rezultatQuizz);
    setSelectedCapitol(null);
    setSelectedIntrebare(null);
    setSelectedUtilizator(null);
    setEditMode(true);
  };

  const handleEditUtilizator = (utilizator) => {
    setSelectedUtilizator(utilizator);
    setSelectedCapitol(null);
    setSelectedIntrebare(null);
    setSelectedRezultatQuizz(null);
    setEditMode(true);
  };

  const handleCancelEdit = () => {
    setSelectedCapitol(null);
    setSelectedIntrebare(null);
    setSelectedRezultatQuizz(null);
    setSelectedUtilizator(null);
    setEditMode(false);
  };

  const handleAddCapitol = () => {
    setSelectedCapitol(null);
    setSelectedIntrebare(null);
    setSelectedRezultatQuizz(null);
    setSelectedUtilizator(null);
    setEditMode('capitol');
  };

  const handleAddIntrebare = () => {
    setSelectedCapitol(null);
    setSelectedIntrebare(null);
    setSelectedRezultatQuizz(null);
    setSelectedUtilizator(null);
    setEditMode('intrebare');
  };

  const handleAddRezultatQuizz = () => {
    setSelectedCapitol(null);
    setSelectedIntrebare(null);
    setSelectedRezultatQuizz(null);
    setSelectedUtilizator(null);
    setEditMode('rezultatQuizz');
  };

  const handleAddUtilizator = () => {
    setSelectedCapitol(null);
    setSelectedIntrebare(null);
    setSelectedRezultatQuizz(null);
    setSelectedUtilizator(null);
    setEditMode('utilizator');
  };

  const handleSubmit = () => {
    setSelectedCapitol(null);
    setSelectedIntrebare(null);
    setSelectedRezultatQuizz(null);
    setSelectedUtilizator(null);
    setEditMode(false);
  };

  return (
    <div className="container">
      <h1>Panou Administrare</h1><LogoutButton />
      {!editMode ? (
        <div>
          <h2>Administreaza Capitole</h2>
          <CapitoleList onEdit={handleEditCapitol} />
          <button onClick={handleAddCapitol}>Adauga Capitol</button>

          <h2>Administreaza Intrebari</h2>
          <IntrebariList onEdit={handleEditIntrebare} />
          <button onClick={handleAddIntrebare}>Adauga Intrebare</button>

          <h2>Administreaza Rezultate Quizz</h2>
          <RezultatQuizzList onEdit={handleEditRezultatQuizz} />
          <button onClick={handleAddRezultatQuizz}>Adauga Rezultat Quizz</button>

          <h2>Administreaza Utilizatori</h2>
          <UtilizatorList onEdit={handleEditUtilizator} />
          <button onClick={handleAddUtilizator}>Adauga Utilizator</button>
        </div>
      ) : (
        <div>
          {selectedCapitol && (
            <div>
              <h2>{selectedCapitol.capitolInvatareId ? 'Editare' : 'Adaugare'} Capitol</h2>
              <CapitolForm onSubmit={handleSubmit} initialCapitol={selectedCapitol} />
            </div>
          )}
          {selectedIntrebare && (
            <div>
              <h2>{selectedIntrebare.intrebareId ? 'Editare' : 'Adaugare'} Intrebare</h2>
              <IntrebariForm onSubmit={handleSubmit} initialIntrebare={selectedIntrebare} />
            </div>
          )}
          {selectedRezultatQuizz && (
            <div>
              <h2>{selectedRezultatQuizz.rezultatQuizzId ? 'Editare' : 'Adaugare'} Rezultat Quizz</h2>
              <RezultatQuizzForm onSubmit={handleSubmit} initialRezultat={selectedRezultatQuizz} />
            </div>
          )}
          {selectedUtilizator && (
            <div>
              <h2>{selectedUtilizator.utilizatorId ? 'Editare' : 'Adaugare'} Utilizator</h2>
              <UtilizatorForm onSubmit={handleSubmit} initialUtilizator={selectedUtilizator} />
            </div>
          )}
          <button onClick={handleCancelEdit}>Anuleaza</button>
        </div>
      )}

      {editMode === 'capitol' && (
        <div>
          <h2>Adaugare Capitol</h2>
          <CapitolForm onSubmit={handleSubmit} />
        </div>
      )}
      {editMode === 'intrebare' && (
        <div>
          <h2>Adaugare Intrebare</h2>
          <IntrebariForm onSubmit={handleSubmit} />
        </div>
      )}
      {editMode === 'rezultatQuizz' && (
        <div>
          <h2>Adaugare Rezultat Quizz</h2>
          <RezultatQuizzForm onSubmit={handleSubmit} />
        </div>
      )}

      {editMode === 'utilizator' && (
        <div>
          <h2>Adaugare Utilizator</h2>
          <UtilizatorForm onSubmit={handleSubmit} />
        </div>
      )}

    </div>
  );
}

export default App;
