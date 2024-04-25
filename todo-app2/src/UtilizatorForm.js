import React, { useState } from 'react';

const UtilizatorForm = ({ onSubmit, initialUtilizator }) => {
    const [utilizator, setUtilizator] = useState(initialUtilizator || { numeUtilizator: '', parola: '', rol: '' });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setUtilizator({ ...utilizator, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch(`/api/Utilizator${initialUtilizator ? `/${initialUtilizator.utilizatorId}` : ''}`, {
                method: initialUtilizator ? 'PUT' : 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(utilizator),
            });
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            onSubmit(utilizator);
            setUtilizator({ numeUtilizator: '', parola: '', rol: '' });
        } catch (error) {
            console.error('Error submitting data: ', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>Nume Utilizator:
                <input type="text" name="numeUtilizator" value={utilizator.numeUtilizator || ''} onChange={handleChange} />
            </label>
            <label>Parola:
                <input type="password" name="parola" value={utilizator.parola || ''} onChange={handleChange} />
            </label>
            <label>Rol:
                <input type="text" name="rol" value={utilizator.rol || ''} onChange={handleChange} />
            </label>
            <label>Id:
                <input type="text" name="utilizatorId" />
            </label>

            <button type="submit">Salveaza</button>
        </form>
    );
};

export default UtilizatorForm;
