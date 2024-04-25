import React, { useState } from 'react';

const RezultatQuizzForm = ({ onSubmit, initialRezultat }) => {
    const [rezultat, setRezultat] = useState(initialRezultat || { utilizatorId: '', intrebareId: '', scorObtinut: '' });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setRezultat({ ...rezultat, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch(`/api/RezultatQuizz${initialRezultat ? `/${initialRezultat.rezultatQuizzId}` : ''}`, {
                method: initialRezultat ? 'PUT' : 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(rezultat),
            });
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            onSubmit(rezultat);
            setRezultat({ utilizatorId: '', intrebareId: '', scorObtinut: '' });
        } catch (error) {
            console.error('Error submitting data: ', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>Utilizator ID:
                <input type="text" name="utilizatorId" value={rezultat.utilizatorId || ''} onChange={handleChange} />
            </label>
            <label>Intrebare ID:
                <input type="text" name="intrebareId" value={rezultat.intrebareId || ''} onChange={handleChange} />
            </label>
            <label>Scor obtinut:
                <input type="number" name="scorObtinut" value={rezultat.scorObtinut || ''} onChange={handleChange} />
            </label>
            <button type="submit">Salveaza</button>
        </form>
    );
};

export default RezultatQuizzForm;
